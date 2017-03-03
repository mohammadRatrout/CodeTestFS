//Step 1

let Add input =
    match input with
       |"" -> 0
       |input-> input.Split(',','\n') |> Array.map int |> Array.sum // first splitting the string it gave a character array 
                                                              //in which we turn it to int then calculate the sum
                                                              //for this code i will handle multible numbers as accepted value

let resultOfEmpty= Add ""
let resultOfTwoOrMore = Add "1,2,4,5" 
let resultOfNewLine=Add "1\n2,3"
let resultOfNewLine2=Add "1,2\n3"//handling more opperands gave me the power of doing this
                                 //in java i only allowed for two opperands and because of this  
                                 //new line were only allowed before the delimeter
