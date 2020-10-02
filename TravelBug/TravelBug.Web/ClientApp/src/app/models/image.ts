export class Photo {
  constructor(url: string, description?: string) {
    this.url = url;
    this.description = description;
  }
  name = "";
  url = "";
  description = "";
}
