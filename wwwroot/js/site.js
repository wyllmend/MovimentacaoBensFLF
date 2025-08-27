// ------------------------------
// Site.js - Funções globais
// ------------------------------

document.addEventListener("DOMContentLoaded", function () {

    // ----- Notificação de clique no sino -----
    const bell = document.querySelector(".bi-bell");
    if (bell) {
        bell.addEventListener("click", function () {
            alert("Você clicou nas notificações!");
        });
    }

    // ----- Auto-scroll no chat -----
    const chatBody = document.querySelector(".card-body.overflow-auto");
    if (chatBody) {
        chatBody.scrollTop = chatBody.scrollHeight;
    }

    // ----- Envio rápido no chat -----
    const chatForm = document.querySelector(".card-footer form");
    if (chatForm) {
        chatForm.addEventListener("submit", function (e) {
            e.preventDefault();

            const input = chatForm.querySelector("input[type='text']");
            if (input && input.value.trim() !== "") {
                addMessageToChat(input.value.trim());
                input.value = "";
            }
        });
    }

    // Função para adicionar mensagem no chat
    function addMessageToChat(message) {
        if (!chatBody) return;

        const msgDiv = document.createElement("div");
        msgDiv.classList.add("mb-3", "text-end");

        const bubble = document.createElement("div");
        bubble.classList.add("p-2", "bg-primary", "text-white", "rounded", "w-75", "ms-auto");
        bubble.textContent = message;

        msgDiv.appendChild(bubble);
        chatBody.appendChild(msgDiv);

        chatBody.scrollTop = chatBody.scrollHeight; // Scroll automático
    }

});
