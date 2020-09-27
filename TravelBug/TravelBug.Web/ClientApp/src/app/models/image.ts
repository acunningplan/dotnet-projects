export class Image {
  constructor(url: string, description?: string) {
    this.url = url;
    this.description = description;
  }
  name = "";
  url = "";
  description = "";
}
