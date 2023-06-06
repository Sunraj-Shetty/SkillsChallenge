import { Injectable } from '@angular/core';
import { HttpRequest, HttpResponse, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable()
export class CacheInterceptor implements HttpInterceptor {
  private cache: Map<string, CachedResponse> = new Map();

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (request.method !== 'GET') {
      return next.handle(request);
    }

    const cachedResponse = this.cache.get(request.url);
    if (cachedResponse && !this.isExpired(cachedResponse)) {
      return of(cachedResponse.response.clone());
    }

    return next.handle(request).pipe(
      tap(event => {
        if (event instanceof HttpResponse) {
          const expirationTime = new Date().getTime() + 2 * 60 * 1000; // 2 minutes
          this.cache.set(request.url, { response: event.clone(), expiration: expirationTime });
        }
      })
    );
  }

  private isExpired(cachedResponse: CachedResponse): boolean {
    return new Date().getTime() > cachedResponse.expiration;
  }
}

interface CachedResponse {
  response: HttpResponse<any>;
  expiration: number;
}

