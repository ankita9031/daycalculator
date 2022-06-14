<template>
  <Header title="Days Calculator"></Header>
  <Datepicker  v-model="startdate" placeholder="Select Start Date"  utc />
  <Datepicker v-model="enddate"  placeholder="Select End Date"  utc/>
  <label>No of WeekDays : {{noOfWeekDays}}</label><br/>
  <label>No of Business Days : {{noOfBusinessDays}}</label><br/>
  <Datepicker  v-model="phDate" placeholder="Select Public Holiday date"  utc /> 
  <button @click="addPublicHolidays()">Add Public Holiday</button>
  <table>
    <thead>
      <tr>
        <th>Public Holiday Date</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="(publicHoliday,index) in publicHolidays" :key="index">
        <td>
          {{publicHoliday}}
        </td>
      </tr>
    </tbody>
  </table>
  <button @click="calculateNoOfDays()">Calculate WeekDays</button>
  <button @click="calculateNoOfBusinessDays()">Calculate Business Days</button>
 
</template>

<script setup>
import { ref } from 'vue';
import Datepicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css';
const startdate = ref();
const enddate = ref();
const phDate = ref()
</script>

<script>
import axios from 'axios'
import Header from './components/Header.vue'
export default {
  name: 'App',
  components :{Header,},
  data(){
    return {
      startdate:"",
      enddate:"",
      noOfWeekDays:0,
      noOfBusinessDays:0,
      publicHolidays :[],
      phDate:""
    }
  },
  methods:{
    calculateNoOfDays(){
    console.log(this.startdate);
    console.log(this.enddate);
      axios.get('https://localhost:7054/GetWeekdays', {
    params: {
      startDate: this.startdate,
      endDate:this.enddate
    }
  })
  .then(response => (this.noOfWeekDays = response.data)) 
  .catch(function (error) {
    console.log(error);
  })
  .then(function () {
    // always executed
  });  
    },
    calculateNoOfBusinessDays(){
      axios.get('https://localhost:7054/GetBusinessDaysWithPublicHolidayDates', {
      params: {
        startDate: this.startdate,
        endDate:this.enddate,
        publicHolidays:this.publicHolidays.toString()
      }
  })
  .then(response => (console.log(response))) 
  .catch(function (error) {
    console.log(error);
  })
  .then(function () {
    // always executed
  });  
    },
    addPublicHolidays(){
      if(this.phDate.length === 0) return;
      this.publicHolidays.push(this.phDate);
    }
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
button{
 background-color: #04AA6D;
  border: none;
  color: white;
  padding: 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
  border-radius: 20px;
}
.dp__main {
  color: #1976d2;
  height: 40px;
  padding: 10px;
  margin:10px;
  align-items: center;
}
</style>
