import FunFact from "../FunFact/FunFact";

export default class {
  name: string = "";
  introduction: string = "";
  funFacts: FunFact[] = [];
  pictures: Image[] = [];
}

interface Image {
  url: string;
  isMain: boolean;
  description: string;
}
