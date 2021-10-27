import {Injectable, Inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {BehaviorSubject, Observable, Subject} from 'rxjs';
import {JobTitle} from '../models/jobTitle';
import { Job } from '../models/Job';

@Injectable()
export class JobsService {
    private _baseUrl: string;
    private _isLoadingData = new BehaviorSubject<boolean>(false);
    private _jobs: Job[] = [];
    private _jobTitle: JobTitle;
    public isLoadingData$ = this._isLoadingData.asObservable();
    public searchJobTitle = new Subject<JobTitle>();
    public searchJobTitle$ = this.searchJobTitle.asObservable();

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._baseUrl = baseUrl + 'api/';

        this.searchJobTitle$.subscribe(title =>{
            this._jobTitle = title;
            this.updateJobsData();
        });
    }

    get jobs(): Job[] {
        return this._jobs;
    }

    updateJobsData() {
        if(!this._jobTitle || !this._jobTitle.id || this._jobTitle.id < 1){
            return;
        }
        this._isLoadingData.next(true);

        this.search(this._jobTitle.id)
          .subscribe(jobs => {
            this._jobs = jobs;
            this._isLoadingData.next(false);
          });
    }

    search(value: number): Observable<Job[]> {
        return this.http.get<Job[]>(this._baseUrl + `Job/search?value=${value}`);
    }
}
