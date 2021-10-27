import {Injectable, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';
import {JobTitle} from '../models/jobTitle';

@Injectable()
export class JobTitlesService {
    private _baseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl + 'api/';
    }

    search(value: string): Observable<JobTitle[]> {
        return this.http.get<JobTitle[]>(this._baseUrl + `JobTitle/search?value=${value}`);
    }
}
