<template>
  <div class="sidenav bg-primary">
         <img alt="Logo Finans" src="../assets/logo.png">
         <div class="login-main-text">
            <h2>Finans<br> Controle sua vida financeira!</h2>
            <p>Acesse sua conta ou registre-se já!</p>
         </div>
      </div>
      <div class="main">
         <div class="col-md-6 col-sm-12">
            <div class="login-form">
               <form>
                  <div class="form-group">
                     <label>Email:</label>
                     <input type="email" class="form-control" placeholder="Email"
                     v-model.lazy.trim="login.email">
                  </div>
                  <div class="form-group">
                     <label>Senha:</label>
                     <input type="password" class="form-control" placeholder="Senha"
                     v-model='login.senha'>
                  </div> <br>
                  <button type="submit" class="btn btn-primary">Login</button>
                  <button type="submit" class="btn btn-secondary">Registrar</button>
                  <button type="submit" class="btn btn-danger" @click.prevent="ver()">Ver</button>
               </form>
            </div>
         </div>
      </div>
</template>

<script>
export default {
    name: 'telaLogin',
    methods: {
        ver(){
            console.log('Email: ' + this.login.email + ' Senha: ' + this.login.senha)
        }
    },
    data(){
        return{
            login: {
                email: '',
                senha: '',
            }
        }
    }
}
</script>

<style>
    body {
    font-family: "Lato", sans-serif;
}



.main-head{
    height: 150px;
    background: #FFF;
   
}

.sidenav {
    height: 100%;
    background-color: #000;
    overflow-x: hidden;
    padding-top: 20px;
}


.main {
    padding: 0px 10px;
}

@media screen and (max-height: 450px) {
    .sidenav {padding-top: 15px;}
}

@media screen and (max-width: 450px) {
    .login-form{
        margin-top: 10%;
    }

    .register-form{
        margin-top: 10%;
    }
}

@media screen and (min-width: 768px){
    .main{
        margin-left: 40%; 
    }

    .sidenav{
        width: 40%;
        position: fixed;
        z-index: 1;
        top: 0;
        left: 0;
    }

    .login-form{
        margin-top: 80%;
    }

    .register-form{
        margin-top: 20%;
    }
}


.login-main-text{
    margin-top: 20%;
    padding: 60px;
    color: #fff;
}

.login-main-text h2{
    font-weight: 300;
}


</style>