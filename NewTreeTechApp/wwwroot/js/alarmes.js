const uriAlarmes = window.location.origin + "/api/Alarme";

let alarmes = [];


// Professors
function getAlarmes() {
    fetch(uriAlarmes)
        .then(response => response.json())
        .then(data => _displayAlarmes(data))
        .catch(error => console.error('Unable to get the Alarms', error));
}

function deleteAlarme(id) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this Alarm file!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willdelete) => {
            if (willdelete) {
                fetch(`${uriEquipamentos}/${id}`,
                    {
                        method: 'DELETE'
                    })
                    .then(() => getAlarmes())
                    .catch(error => console.error('Unable to delete the alarm', error));
                swal("Poof! Your Alarm file has been deleted!", {
                    icon: "success",
                });
            } else {
                swal("Your Alarm file is safe!");
            }
        });
}


function _displayCountAlarmes(alarmeCount) {
    const name = (alarmeCount === 1) ? 'Alarme' : 'Alarmes';
    document.getElementById("counter").innerText = `${alarmeCount} ${name}`;
}

function _displayAlarmes(data) {
    const tBody = document.getElementById("alarmes");
    tBody.innerHTML = '';

    _displayCountAlarmes(data.length);

    const button = document.createElement('button');
    const a = document.createElement('a');


    data.forEach(alarme => {

        let editAlarme = a.cloneNode(false);
        editAlarme.classList.add('btn');
        editAlarme.classList.add('btn-secondary');
        editAlarme.innerText = 'Edit';
        let urlEditAlarme = window.location.origin + '/alarme/edit/' + alarme.id;
        editAlarme.setAttribute('href', urlEditAlarme);

        let detailsAlarme = a.cloneNode(false);
        detailsAlarme.innerText = 'Details';
        detailsAlarme.classList.add('btn');
        detailsAlarme.classList.add('btn-info');
        let urlDetailsAlarme = window.location.origin + '/alarme/details/' + alarme.id;
        detailsAlarme.setAttribute('href', urlDetailsAlarme);

        let deleteAlarme = button.cloneNode(false);
        deleteAlarme.innerText = 'Delete';
        deleteAlarme.classList.add('btn');
        deleteAlarme.classList.add('btn-danger');
        deleteAlarme.setAttribute('onclick', `deleteAlarme(${alarme.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(alarme.descricao);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let classificacaoDoAlarme = "";
        if (alarme.classificacao === 1)
            classificacaoDoAlarme = "Alto";
        else if (alarme.classificacao === 2)
            classificacaoDoAlarme = "Médio";
        else if (alarme.classificacao === 3)
            classificacaoDoAlarme = "Baixo";
        let textNode2 = document.createTextNode(classificacaoDoAlarme);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let textNode3 = document.createTextNode(alarme.equipamento.nomeDoEquipamento);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        let textNode4 = document.createTextNode(alarme.dataDeCadastro);
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(4);
        td5.appendChild(editAlarme);

        //let td6 = tr.insertCell(5);
        //td6.appendChild(detailsEquipamento);

        let td7 = tr.insertCell(5);
        td7.appendChild(deleteAlarme);

    });
    alarmes = data;
}

function SearchAlarme() {
    var input, filter, tBody, tr, colName, i, textValue;
    var cont = 0;
    input = document.getElementById("searchAlarme");
    filter = input.value.toUpperCase();
    tBody = document.getElementById("alarmes");
    tr = tBody.getElementsByTagName("tr");

    for (i = 0; i < tr.length; i++) {

        colName = tr[i].getElementsByTagName('td')[0].innerHTML.toUpperCase();


        if (colName.indexOf(filter) > -1) {
            tr[i].style.display = "";
            cont = cont + 1;
            _displayCountAlarmes(cont)
        } else {
            tr[i].style.display = "none";
            _displayCountAlarmes(cont)
        }

    }
}

function NewAlarme() {
    const newAlarme = document.getElementById("newAlarme");
    const urlAlarme = window.location.origin + "/Alarme/new";
    newAlarme.setAttribute('href', urlAlarme);
}

