import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { tap } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { Assets } from "../models/assets";
import { Profile } from "../models/profile";

@Injectable({
  providedIn: "root",
})
export class AppResolverService {
  constructor(private httpClient: HttpClient) {}

  resolve(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Assets | Observable<Assets> | Promise<Assets> {
    let assets = new Assets();

    
    // var file = new File([""], "/assets/close.svg", {
    //   type: "image",
    // });

    // let reader = new FileReader();
    // reader.readAsDataURL(file);
    // reader.onload = () => {
    //   assets.images.cancelUpload = reader.result;
    // };



    // let src = 'http://www.downgraf.com/wp-content/uploads/2014/09/01-progress.gif'; //Just a random loading gif found on google.
    // this.httpClient.get('http://example.com/mycdn/stuff.jpg')
    //    .subscribe(response => {
    //       let urlCreator = window.URL;
    //       // src = urlCreator.createObjectURL(response.blob());
    //    });



    // this.httpClient.get("/assets/close.svg").pipe(tap((r) => {
    //   let reader = new FileReader();
    //   reader.readAsDataURL(new Blob());
    //   reader.onload = () => {
    //     assets.images.cancelUpload = reader.result;
    //   };
    // }));
    
    // var file = new File(["foo"], "foo.txt", {
    //   type: "text/plain",
    // });

    // Get data url to display selected image
    // var reader = new FileReader();
    // reader.readAsDataURL(file);
    // reader.onload = (pe: ProgressEvent) => {
    //   // var arrayBuffer = reader.result;

    //   this.photosToUpload.push(reader.result);
    // };

    return assets;
  }
}
