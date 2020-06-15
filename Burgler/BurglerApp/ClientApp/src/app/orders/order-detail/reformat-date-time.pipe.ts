import { Pipe, PipeTransform } from "@angular/core";
import * as moment from "moment";

@Pipe({
  name: "reformatDateTime",
})
export class ReformatDateTimePipe implements PipeTransform {
  transform(value: Date, ...args: unknown[]): unknown {
    return moment(value).format("MMMM Do YYYY, h:mmA");
  }
}
