import { NgModule } from "@angular/core";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ServerModule } from "@angular/platform-server";
import { ModuleMapLoaderModule } from "@nguniversal/module-map-ngfactory-loader";
import { ToastrModule } from "ngx-toastr";
import { AppComponent } from "./app.component";
import { AppModule } from "./app.module";

@NgModule({
  imports: [
    AppModule,
    ServerModule,
    ModuleMapLoaderModule,
    BrowserAnimationsModule, // required animations module
    ToastrModule.forRoot(),
  ],
  bootstrap: [AppComponent],
})
export class AppServerModule {}
