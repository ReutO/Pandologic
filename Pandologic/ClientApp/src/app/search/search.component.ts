import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ValidatorFn, AbstractControl, ValidationErrors  } from '@angular/forms';
import {JobTitle} from '../models/jobTitle';
import {switchMap, debounceTime, tap, finalize, filter, distinctUntilChanged} from 'rxjs/operators';
import { JobTitlesService } from '../services/jobTitlesService';
import { JobsService } from '../services/jobsService';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: [ './search.component.css' ]
})
export class SearchComponent implements OnInit{
  
  constructor(private fb: FormBuilder, 
    private jobTitlesService: JobTitlesService, 
    private jobsService: JobsService){}
  
  jobSearchForm: FormGroup;
  filteredJobTitles: JobTitle[] = [];
  isLoading = false;

  ngOnInit(){
    this.jobSearchForm =  this.fb.group({
      jobInput: this.fb.control(null, [Validators.required, this.forbiddenJobTitle()])
    });
  
    this.jobSearchForm.get('jobInput').valueChanges
    .pipe(
      debounceTime(400),
      distinctUntilChanged()
    )
    .subscribe((value: string) =>{
        if(!value || !value.length || value.length < 2){
          this.filteredJobTitles = [];
          return;
        }

        this.isLoading = true;

        this.jobTitlesService.search(value)
          .subscribe(titles => {
            this.filteredJobTitles = titles;
            this.isLoading = false;
          });

      });
  }

  forbiddenJobTitle(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null =>  {
      return !control.value || !control.value.id || control.value.id < 1 ? {forbiddenJobTitle: true} : null;
    }
  }

  displayTitleOptions(jobTitle: JobTitle) {
    if (jobTitle) { return jobTitle.name; }
  }

  onSearchJobs(){
    if(this.jobSearchForm.invalid){
      return;
    }
    var searchValue = this.jobSearchForm.get('jobInput').value;
    this.jobsService.searchJobTitle.next(searchValue);
  }

}
