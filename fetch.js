function Chamar_Dados(url){
    //event.preventDefault();
    // const peso = document.querySelector("input[name=Peso]").value;
    // const altura = document.querySelector("input[name=Altura]").value;
    fetch(`http://localhost:5000/HelloWorld/${url}`, {
        method: "GET",
        
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        }
    })
        .then(r => r.json())
        .then(dados => {
            console.log(dados);
            document.querySelector("#resposta").innerHTML = dados.nome;
        });
}