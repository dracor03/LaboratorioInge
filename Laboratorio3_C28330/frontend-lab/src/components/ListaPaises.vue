<template>
  <div class="container mt-5">
    <h1 class="display-4 text-center">Lista de países</h1>
    <div class="row justify-content-end">
      <div class="col-2">
        <a href="/pais">
          <button type="button" class="btn btn-outline-secondary float-right">
            Agregar país
        </button>
        </a>
      </div>
    </div>
    <div v-if="loading">Cargando...</div> <!-- Mensaje de carga -->
    <table v-else class="table is-bordered is-striped is-narrow is-hoverable is-fullwidth">
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Continente</th>
          <th>Idioma</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(pais, index) of paises" :key="index">
          <td>{{ pais.nombre }}</td>
          <td>{{ pais.continente }}</td>
          <td>{{ pais.idioma }}</td>
          <td>
            <button class="btn btn-secondary btn-sm">Editar</button>
            <button class="btn btn-danger btn-sm" @click="eliminarPais(index)">
              Eliminar
            </button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

  
  <script>
  import axios from "axios";
  
  export default {
    name: "ListaPaises",
    data() {
      return {
        paises: [],
        loading: true
      };
    },
    methods: {
      eliminarPais(index) {
        this.paises.splice(index, 1); 
      },
      obtenerTareas() {
        console.log("Realizando solicitud a la API...");
        this.loading = true;  // Mostrar "Cargando..." al inicio
        axios.get("https://localhost:7182/api/Paises")
          .then((response) => {
            console.log(response.data);  // Verifica la respuesta en la consola
            this.paises = response.data;
            this.loading = false;  // Detenemos la carga
          })
          .catch((error) => {
            console.error("Error al obtener países:", error);
            this.loading = false;  // Detenemos la carga incluso si hubo un error
          });
      },
    },
    created: function () {
      console.log("Componente cargado, ejecutando obtenerTareas");
      this.obtenerTareas();
    },
  };
  </script>
  
  <style lang="scss" scoped>
  </style>
  