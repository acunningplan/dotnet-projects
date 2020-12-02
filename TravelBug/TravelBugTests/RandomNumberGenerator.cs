using System;
using System.Collections.Generic;

public class RandomNumberGenerator {
  public string Generate(int numOfNums) {
    var randomClass = new Random();
    var randomNums = new List<int>();
    for (var i = 0; i < numOfNums; i++) {
      int randomNum = randomClass.Next(1,100);
      randomNums.Add(randomNum);
    };
    var str = "";
    foreach(var i in randomNums) {
      // Convert num to string
      var num = i.ToString();

      // Append string to the output string
      str += num  + ',';
    }
    // Remove last comma
    str = str.Remove(str.Length - 1, 1);
    return str;
  }
}