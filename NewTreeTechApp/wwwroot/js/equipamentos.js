const uriEquipamentos = window.location.origin + "/api/Equipamentos";

let equipamentos = [];


// Professors
function getEquipamentos() {
    fetch(uriEquipamentos)
        .then(response => response.json())
        .then(data => _displayEquipamentos(data))
        .catch(error => console.error('Unable to get the Equipamentos', error));
}

function deleteEquipamento(id) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this Equipamento file!",
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
                    .then(() => getEquipamentos())
                    .catch(error => console.error('Unable to delete the equipamento', error));
                swal("Poof! Your Equipamento file has been deleted!", {
                    icon: "success",
                });
            } else {
                swal("Your Equipamento file is safe!");
            }
        });
}


function _displayCountEquipamentos(equipCount) {
    const name = (equipCount === 1) ? 'Equipamento' : 'Equipamentos';
    document.getElementById("counter").innerText = `${equipCount} ${name}`;
}

function _displayEquipamentos(data) {
    const tBody = document.getElementById("equipamentos");
    tBody.innerHTML = '';

    _displayCountEquipamentos(data.length);

    const button = document.createElement('button');
    const a = document.createElement('a');


    data.forEach(equipamento => {

        let editEquipamento = a.cloneNode(false);
        editEquipamento.classList.add('btn');
        editEquipamento.classList.add('btn-secondary');
        editEquipamento.innerText = 'Edit';
        let urlEditEquipamento = window.location.origin + '/equipamentos/edit/' + equipamento.id;
        editEquipamento.setAttribute('href', urlEditEquipamento);

        let detailsEquipamento = a.cloneNode(false);
        detailsEquipamento.innerText = 'Details';
        detailsEquipamento.classList.add('btn');
        detailsEquipamento.classList.add('btn-info');
        let urlDetailsEquip = window.location.origin + '/equipamentos/details/' + equipamento.id;
        detailsEquipamento.setAttribute('href', urlDetailsEquip);

        let deleteEquip = button.cloneNode(false);
        deleteEquip.innerText = 'Delete';
        deleteEquip.classList.add('btn');
        deleteEquip.classList.add('btn-danger');
        deleteEquip.setAttribute('onclick', `deleteEquipamento(${equipamento.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(equipamento.nomeDoEquipamento);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNode2 = document.createTextNode(equipamento.numeroDeSerie);
        td2.appendChild(textNode2);

        let td3 = tr.insertCell(2);
        let tipoDoEquipamento = "";
        if (equipamento.tipo === 1)
            tipoDoEquipamento = "Tensao";
        else if (equipamento.tipo === 2)
            tipoDoEquipamento = "Corrente";
        else if (equipamento.tipo === 3)
            tipoDoEquipamento = "Óleo";
        let textNode3 = document.createTextNode(tipoDoEquipamento);
        td3.appendChild(textNode3);

        let td4 = tr.insertCell(3);
        console.log(equipamento.dataDeCadastro);
        let textNode4 = document.createTextNode(equipamento.dataDeCadastro);
        td4.appendChild(textNode4);

        let td5 = tr.insertCell(4);
        td5.appendChild(editEquipamento);

        //let td6 = tr.insertCell(5);
        //td6.appendChild(detailsEquipamento);

        let td7 = tr.insertCell(5);
        td7.appendChild(deleteEquip);

    });
    equipamentos = data;
}

function SearchEquipamento() {
    var input, filter, tBody, tr, colName, i, textValue;
    var cont = 0;
    input = document.getElementById("searchEquip");
    filter = input.value.toUpperCase();
    tBody = document.getElementById("equipamentos");
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

function NewEquipamento() {
    const newEquip = document.getElementById("newEquipamento");
    const urlEquipamento = window.location.origin + "/Equipamentos/new";
    newEquip.setAttribute('href', urlEquipamento);
}

