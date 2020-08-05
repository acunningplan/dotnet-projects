import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { LoadingService } from './loading/loading.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit, OnDestroy {
  loadingSub: Subscription;
  loading = false;
  loadingText = "Loading..."

  constructor(private loadingService: LoadingService) {}

  ngOnInit() {
    this.loadingSub = this.loadingService.loadingSubject.subscribe(loadingData => {
      this.loading = loadingData.loading
      this.loadingText = loadingData.loadingText
    });
  }

  ngOnDestroy() {
    this.loadingSub.unsubscribe();
  }
}
