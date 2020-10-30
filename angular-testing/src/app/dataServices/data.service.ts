export class DataService {
  data: 'This is a piece of data'

  getDetails() {
    const resultPromise = new Promise<string>((resolve, reject) => {
      setTimeout(() => {
        resolve('Data')
      }, 1500)
    })
    return resultPromise;
  }
}
