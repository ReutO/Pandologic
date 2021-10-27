import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Job } from '../models/Job';
import { JobsService } from '../services/jobsService';
import {MatPaginator, MatSort, MatTableDataSource} from '@angular/material';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: [ './jobs.component.css' ]
})
export class JobsComponent implements OnInit, AfterViewInit{
  jobs: Job[] = [];
  isLoading: boolean = false;
  displayedColumns = ['index', 'jobTitleDescription', 'educationLevel', 'clicks', 'applicants'];
  dataSource: MatTableDataSource<Job>;

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  @ViewChild(MatSort, {static: true}) sort: MatSort;

  constructor(private jobsService: JobsService){}

  ngAfterViewInit(){
    this.setDataSourceAttributes();
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
  }

  setDataSourceAttributes() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  ngOnInit(){
    this.dataSource = new MatTableDataSource(this.jobs);
    
    this.jobsService.isLoadingData$.subscribe(value =>{
      this.isLoading = value;
      this.jobs = this.jobsService.jobs;
      this.dataSource.data = this.jobs;
    });
  }
}
