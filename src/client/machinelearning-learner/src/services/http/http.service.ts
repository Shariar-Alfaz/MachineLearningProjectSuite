import {
  HttpClient,
  HttpErrorResponse,
  HttpEventType,
  HttpHeaders,
  HttpParams,
} from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { catchError, map, Observable, Subject, throwError } from 'rxjs';
import { HttpAppError } from '../../models/type/app.type';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  private http = inject(HttpClient);
  private cancelUploadSubject = new Subject<void>();

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
    }),
    withCredentials: true,
  };
  constructor() {}

  private formatErrors(error: HttpErrorResponse) {
    let errorx: HttpAppError = {
      errorMesage: `${
        error.status == 0
          ? 'Network error: Please check your internet connection or try again later.'
          : `Status code:${error.status}, ${error.message}`
      }`,
      statusCode: error.status,
    };
    return throwError(errorx);
  }

  get(path: string, params: HttpParams = new HttpParams()): Observable<any> {
    return this.http
      .get(path, { params, ...this.httpOptions })
      .pipe(catchError(this.formatErrors));
  }

  put(path: string, body: Object = {}): Observable<any> {
    return this.http
      .put(path, JSON.stringify(body), this.httpOptions)
      .pipe(catchError(this.formatErrors));
  }

  post(path: string, body: Object = {}): Observable<any> {
    return this.http
      .post(path, JSON.stringify(body), this.httpOptions)
      .pipe(catchError(this.formatErrors));
  }

  postForm(path: string, body: FormData): Observable<any> {
    const httpOptions = {
      withCredentials: true,
    };
    return this.http
      .post(path, body, httpOptions)
      .pipe(catchError(this.formatErrors));
  }

  delete(path: string): Observable<any> {
    return this.http
      .delete(path, this.httpOptions)
      .pipe(catchError(this.formatErrors));
  }

  getErrorMessage(statusCode: number): string {
    switch (statusCode) {
      case 400:
        return 'Bad Request. The server could not understand the request due to invalid syntax.';
      case 401:
        return 'Unauthorized. The client must authenticate itself to get the requested response.';
      case 403:
        return 'Forbidden. The client does not have access rights to the content.';
      case 404:
        return 'Not Found. The server can not find the requested resource.';
      case 500:
        return "Internal Server Error. The server has encountered a situation it doesn't know how to handle.";
      case 502:
        return 'Bad Gateway. The server was acting as a gateway or proxy and received an invalid response from the upstream server.';
      case 503:
        return 'Service Unavailable. The server is not ready to handle the request.';
      case 504:
        return 'Gateway Timeout. The server is acting as a gateway or proxy and did not get a response from the upstream server in time.';
      case 0:
        return 'Network error: Please check your internet connection or try again later.';
      default:
        return `An unexpected error occurred. Status code: ${statusCode}`;
    }
  }

  uploadFile(
    p0: string,
    file: File,
    onProgress: (progress: number) => void,
    url: string
  ): Observable<any> {
    const formData = new FormData();
    formData.append('file', file, file.name);
    const httpOptions = {
      withCredentials: true,
    };
    return this.http
      .post(url, formData, httpOptions)
      .pipe(catchError(this.formatErrors));
  }

  uploadFileWithProgress(
    file: File,
    url: string,
    onProgress: (progress: number) => void
  ): Observable<any> {
    const formData: FormData = new FormData();
    formData.append('file', file, file.name);
    return this.http
      .post(url, formData, {
        headers: new HttpHeaders({
          enctype: 'multipart/form-data',
        }),
        reportProgress: true,
        observe: 'events',
      })
      .pipe(
        map((event) => {
          switch (event.type) {
            case HttpEventType.UploadProgress:
              const progress = Math.round(
                (100 * event.loaded) / (event.total || 100)
              );
              onProgress(progress);
              break;
            case HttpEventType.Response:
              return event.body;
            default:
              return `Unexpected event: ${event.type}`;
          }
          return null; // Add this line to return a value for all code paths
        }),
        catchError(this.formatErrors)
      );
  }

  cancelUpload() {
    this.cancelUploadSubject.next();
  }

  getFile(url: string): Observable<any> {
    return this.http
      .get(url, { responseType: 'blob', ...this.httpOptions })
      .pipe(catchError(this.formatErrors));
  }
}
