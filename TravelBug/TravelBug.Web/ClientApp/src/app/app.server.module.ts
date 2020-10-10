import { NgModule } from "@angular/core";
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
    ToastrModule.forRoot(),
  ],
  bootstrap: [AppComponent],
})
export class AppServerModule {}
