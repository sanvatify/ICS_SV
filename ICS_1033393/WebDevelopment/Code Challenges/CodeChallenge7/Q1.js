const firstNumber = parseFloat(prompt("Enter 1st Number: "));
const secondNumber = parseFloat(prompt());
if(isNaN(firstNumber)||isNaN(secondNumber)){
    console.log("Invalid Input, Please Enter Valid Numbers");
}
else{
    const operation = prompt("Choose an operation: \n1. Multiply \n2. Divide \n3. Add \n4. Subtract");
    let result;
    switch(operation){
        case "1": result = firstNumber*secondNumber; 
        console.log('Result: $(firstNumber)*$(secondNumber) = $(result)');
        break;
        case "2": if(secondNumber==0){
            console.log("Division By Zero Is Not Allowed");
        }
        else{
            result = firstNumber/secondNumber;
            console.log('Result: $(firstNumber)/$(secondNumber) = $(result)'); 
        }
        break;
        case "3": result = firstNumber+secondNumber;
        console.log('Result: $(firstNumber)+$(secondNumber) = $(result)');
        break;
        case "4": result = firstNumber-secondNumber;
        console.log('Result: $(firstNumber)-$(secondNumber) = $(result)');
        break;
        default: console.log("Please Select A Valid Option")
    }
}