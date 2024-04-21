



// const type = document.querySelector('#type').value;
// const udl = document.getElementById('udl');
// const strike = document.getElementById('strike');
// const tenor = document.getElementById('tenor');
// const rate = document.getElementById('rate');
// const steps = document.getElementById('steps');
// const trails = document.getElementById('trails');
// const barrierValue = document.getElementById('bar');
// const volatility = document.getElementById('vol');
// const rebate = document.getElementById('rabate');

// const isCall = document.getElementById('isCall');
// const upOut = document.getElementsByName('knockType');
// const CV = document.getElementById('deltaControl');
// const Anti  = document.getElementById('antithetic');
// const Multi = document.getElementById('multithreading');
// const choice = document.querySelector('input[name = "knocktype"]:checked');

//pass true or false to selected value 
// function onClick(choice) 
// {
//     if(choice == 'UpOut') {
//         this.UpOut = true;
//     } else if(choice=='DownOut') {
//         this.DownOut = true;
//     } else if(choice =='UpIn') {
//         this.UpIn = true;
//     } else if (choice == 'DownIn') {
//         this.DownIn = true;
//     } else {
//         console.log('choice does not exist');
//     }

// };


//click event triggers the calculation
//need to figuer out how to pass the input to the controller

const inputs = document.getElementById('form');
const log = document.getElementById('log');

if(inputs){
    inputs.addEventListener('submit', clickEvent);    
}

function clickEvent(event){
    
    event.preventDefault();
   

    var anti = (inputs.antithetic.value === 'True');
    var cv = (inputs.deltaControl.value === 'True');
    var multi = (inputs.multithreading.value === 'True');
    var is = (inputs.isCall.value === 'True');
  

    var field ={
        "type": inputs.type.value, 
        "Strike":inputs.strike.value,
        "S":inputs.udl.value,
        "T":inputs.tenor.value,
        "r":inputs.rate.value,
        "sigma":inputs.vol.value,
        "steps":inputs.steps.value,
        "trails":inputs.trails.value,
        "Anti" : anti,
        "CV": cv,
        "Multi": multi,
        "rebate":inputs.rebate.value,
        "isCall":is,
        "bar":inputs.bar.value,
        "UpOut": document.getElementById("UpOut").checked,
        "UpIn": document.getElementById("UpIn").checked,
        "DownOut":document.getElementById("DownOut").checked,
        "DownIn":document.getElementById("DownIn").checked
    }

const list = document.createDocumentFragment();

    fetch('http://localhost:5099/calculate', {
        method: "POST",
        headers:{
            'Content-Type':'application/json'
        },
        body: JSON.stringify(field)
    })
        .then(response => response.json())
        // .then(data => {console.log(data)})
        // .catch(err => console.log(err));

        .then(data => {
            console.log(data)
            

            let results = Object.values(data);
            document.getElementById('price').innerHTML= "Price: "+ results[0].toFixed(2);
            document.getElementById('SE').innerHTML= "StandardError: "+ results[1].toFixed(2);

            document.getElementById('delta').innerHTML= "Delta: "+ results[2].toFixed(2);

            document.getElementById('gamma').innerHTML= "Gamma: "+ results[3].toFixed(2);

            document.getElementById('vega').innerHTML= "Vega: "+ results[4].toFixed(2);

            document.getElementById('theta').innerHTML= "Theta: "+ results[5].toFixed(2);
            document.getElementById('rho').innerHTML= "Rho: "+ results[6].toFixed(2);



            
            // console.log(results)
          //  results.map(function(result){

           
    



             
               // let li = document.createElement('li');

                // let price = document.createElement('result');
                // let gemma = document.createElement('gamma');
                // let rho = document.createElement('rho');
                // let theta = document.createElement('theta');
                // let vega = document.createElement('vega');
                // let se = document.createElement('se');

                // price.innerHTML = `${result.price}`;
                // gemma.innerHTML = `${result.gemma}`;
                // rho.innerHTML = `${result.rho}`;
                // theta.innerHTML = `${result.theta}`;
                // vega.innerHTML = `${result.vega}`;
                // se.innerHTML = `${result.se}`;

                // var price1 = new DOMParser().parseFromString(price, "text/xml");
                // console.log(price1.firstChild.innerHTML); 
                // var gemma1 = new DOMParser().parseFromString(gemma, "text/xml");

                // var rho1 = new DOMParser().parseFromString(rho, "text/xml");

                // var theta1 = new DOMParser().parseFromString(theta, "text/xml");

                // var vega1 = new DOMParser().parseFromString(vega, "text/xml");

                // var se1 = new DOMParser().parseFromString(se, "text/xml");
                
                // li.appendchild(price1);
                // li.appendchild(gemma1);
                // li.appendchild(rho1);
                // li.appendchild(theta1);
                // li.appendchild(vega1);
                // li.appendchild(se1);
                // list.appendchild(li);

            //}); 
             })
        
        .catch(err => console.log(err));


       //log.innerText = result;

    // fetch('http://localhost:5099/calculate', {
    //     method: "POST",
    //     headers:{
    //         'Content-Type':'application/json'
    //     },
    //     body: JSON.stringify(field)
    // })
    //     .then(response => response.json())
    //     .then(data => {
    //         console.log(data)
    //     })
    //     .catch(err => console.log(err));


    //     log.innerText = data;


}




// adding row to my table ( after the calculation)
// let display = document.getElementById("button1");
// display.addEventListener("click", displayOutput);

// function displayOutput(){
//     var output = document.getElementById("output");
//     //delete a row
//     let rowcount = output.rows.length;
//     // for (let j = 0; j < rowcount; j++) {
//     //     output.deleteRow(-1);
//     // }
//     //adding a new row
//     for (let i = 0; i < rowcount; i++){
//         var row = output.insertRow(row);
//         var idCol = row.insertCell(0);
//         // idCol.innerHTML = rowcount[i].id;
//     }

// }

// var row = output.insertRow(0);
// var cell1 = row.insertCell(0);
// var cell2 = row.insertCell(1);


// cell1.innerHTML = tenor;
// cell2.innerHTML = trails;
//var newRow = display.insertRow(row);

// const request = new XMLHttpRequest();
// request.open("POST", "http://localhost:5099/calculate", true);
// request.setRequestHeader("Content-Type", "application/json");

// request.onload = function(){
//     const serverRespose = document.getElementById('')
// }

// const obj ={ hello: "world"};

// request.onreadystatechange =() =>{
//     if(request.readyState === XMLHttpRequest.DONE && request.status ===201){
        
//     }
//     else if (request.readyState ===XMLHttpRequest.DONE && request.status===400){
//         //alter the user to a 400 from the server = error! 
//     }
// }

//request.send(JSON.stringify(obj))


















 