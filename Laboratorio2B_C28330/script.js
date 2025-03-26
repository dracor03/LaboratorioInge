// Método para agregar elementos a la lista
function agregar() {
    const lista = document.getElementById('lista');

    const nuevoNumero = lista.children.length + 1;

    const nuevoElemento = document.createElement('li');
    nuevoElemento.textContent = `Elemento${nuevoNumero}`;

    lista.appendChild(nuevoElemento);
}

// Método para cambiar el fondo
function cambiarFondo() {
    const body = document.body;

    if (body.style.backgroundColor === '' || body.style.backgroundColor === 'white') {
        const r = Math.floor(Math.random() * 256);
        const g = Math.floor(Math.random() * 256);
        const b = Math.floor(Math.random() * 256);

        body.style.backgroundColor = `rgb(${r}, ${g}, ${b})`;
    } else {
        body.style.backgroundColor = 'white';
    }
}

// Método para borrar el último elemento
function borrar() {
    const lista = document.getElementById('lista');

    if (lista.children.length > 0) {
        lista.removeChild(lista.lastElementChild);
    }
}