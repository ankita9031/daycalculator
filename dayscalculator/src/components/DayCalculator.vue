<template>
    <div class="row">
      <div class="col p-3" text-bold>
       Start Date:
       <Datepicker  v-model="startdate" placeholder="Select Start Date" :startTime="startTime" :enableTimePicker="false" utc />
      </div>
      <div class="col p-3">
        <label>End Date:</label>
        <Datepicker v-model="enddate"  placeholder="Select End Date" :startTime="startTime" :enableTimePicker="false" utc/>
      </div>
    </div>
  
    <div> 
      <div class="row">
        Add Public Holiday
      </div>
      <div class="row">
        <Datepicker  v-model="phDate" placeholder="Select Public Holiday date" :startTime="startTime" :enableTimePicker="false"  utc /> 
      </div>
      <br/>
      
      <table class="table table-bordered">
        <thead>
          <tr>
            <th>Public Holiday Date</th>
          </tr>
        </thead>
        <tbody>
          <tr v-if="this.publicHolidays.length == 0">
            <td>"No public holiday added"</td>
          </tr>
          <tr v-for="(publicHoliday,index) in publicHolidays" :key="index">
            <td>
              {{new Date(publicHoliday)}}
            </td>
          </tr>
        </tbody>
      </table>
      <br/>
      <div class="row">
        <button class="btn btn-success" type="button"  @click="addPublicHolidays()" >
          Add Public Holidays
        </button>
        <br/>
      </div>
    </div>
    <br/><br/>

<div class="row">
  <div class="col">
    <button @click="calculateNoOfDays()" class="btn btn-primary btn-md">Calculate WeekDays</button>
  </div>
   <div class="col">
   <button @click="calculateNoOfBusinessDays()" class="btn btn-primary btn-md">Calculate Business Days</button>
  </div>
</div>
    
    <br/>
    <br/>
    <label>No of WeekDays : {{noOfWeekDays}}</label><br/>
    <label>No of Business Days : {{noOfBusinessDays}}</label><br/>

</template>

<script setup>
import { ref } from 'vue';
import Datepicker from '@vuepic/vue-datepicker';
import '@vuepic/vue-datepicker/dist/main.css';
const startdate = ref();
const enddate = ref();
const phDate = ref();
const startTime = ref({ hours: 0, minutes: 0 });
</script>

<script>
import axios from 'axios'
export default {
  name: 'DayCalulator',
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
  .then(response => (this.noOfBusinessDays = response.data)) 
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
      this.phDate = "";
    }
  }
}
</script>

<style scoped>
.dp__main {
  color: #1976d2;
  height: 40px;
  padding: 10px;
  margin:10px;
  align-items: center;
}
</style>
