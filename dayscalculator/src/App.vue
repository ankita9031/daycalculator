<template>
  <div class="container-sm p-50 my-5">
    <Header title="Days Calculator"></Header>
   <DayCalculator/>
  </div>
  
 
</template>

<script>
import DayCalculator from './components/DayCalculator.vue'
import Header from './components/Header.vue'
export default {
  name: 'App',
  components :{Header,DayCalculator},
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  text-align: center;
  color: #2c3e50;
  width:50%;
  margin:auto;
}
</style>
