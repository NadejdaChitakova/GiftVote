import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../services/auth.service';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {

  let authService = inject(AuthService)
  let authToken = authService.getToken();

  if(authToken != null) {

    const reqWithToken = req.clone({
      headers: req.headers.set('Authorization', `Bearer ${authToken}`),
      });
    return next(reqWithToken)
  }

  return next(req);
};
