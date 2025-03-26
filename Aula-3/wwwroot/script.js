const API = "http://localhost:5000/usuario";


document.getElementById("usuaroform").addEventListener("submit" , salvarUsuario);
carregarUsuarios();

function carregarUsuarios() {
    fetch(API)
        .then(res => res.json())
        .then(data => {
            const tbody = document.querySelector("#tabelaUsuarios tbody");   
            tbody.innerHTML = "";

            data.forEach(usuario => { 
                tbody.innerHTML += `
                    <tr>
                        <td>${usuario.nome}</td>
                        <td>${usuario.senha}</td>
                        <td>${usuario.ramal}</td>
                        <td>${usuario.especialidade}</td>
                        <td>
                            <button onclick="editarUsuario(${usuario.id})">Editar</button>
                            <button onclick="excluirUsuario(${usuario.id})">Excluir</button>
                        </td>
                    </tr>
                `;
            });
        })
        .catch(error => console.error("Erro ao carregar usuários:", error));
}
