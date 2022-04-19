<template>
  <tela-login></tela-login>
</template>

<script>
// import HelloWorld from './components/HelloWorld.vue'
import telaLogin from './components/telaLogin.vue'

export default {
  name: 'App',
  components: {
    telaLogin,
    // HelloWorld
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
