import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MiniBlogComponent } from './mini-blog/mini-blog.component';
import { MiniBlogFormComponent } from './mini-blog-form/mini-blog-form.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [AppComponent, MiniBlogComponent, MiniBlogFormComponent],
  imports: [BrowserModule, FormsModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
