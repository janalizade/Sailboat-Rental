<template>
   <v-app >
      <v-main>
         <v-container fluid fill-height>
            <v-layout align-center justify-center>
               <v-flex xs12 sm8 md4>
                  <v-card class="elevation-12">
                     <v-toolbar dark color="primary">
                        <v-toolbar-title>Booking     {{lessorName}}
                     </v-toolbar-title>
                     </v-toolbar>
                     <v-card-text>
                     <form ref="form" @submit.prevent="createLessor()">
                                                     
                           <v-select
                              v-model="boats"
                              :items="boats"
                              :error-messages="errors"
                              label="Select Boat"
                              data-vv-name="select"
                              required
                           ></v-select>
                            <v-text-field
                              v-model="customerId"
                              name="customerId"
                              label="Customer personNumber"
                              type="text"
                              placeholder="Customer Id"
                              required
                           ></v-text-field>
                           <v-space></v-space>
                           <label for="meeting-time">Choose a time for booking boat:</label>
                           <input type="datetime-local" id="meeting-time" name="meeting-time" >
                           <div style= "margin-top:30px;display:flex">
                           <v-btn type="submit" color="orange"    text  value="submit">Book</v-btn>
                           <v-btn   color="orange"  text  @click="returnCategoryPage()"> Category PAGE </v-btn>               
                           </div>
                      </form>
                     </v-card-text>
                  </v-card>
                
               </v-flex>
            </v-layout>
         </v-container>
      </v-main>
   </v-app>
</template>
<script>


export default {
  data() {
    return {
      categories: [ ],
      boats:[],
      boatTitles:[],
      categoryTitles:[],
      lessorName: "",
      addresss: "",
      items:{}
    };
  },
  methods: {
   returnCategoryPage(){
    this.$router.replace('/category');
   },
   changeCategory(){
      
    
    
   
   }
   },
   created(){
      
      this.lessorName=localStorage.getItem('lessorName');
    
    
var lessorId=localStorage.getItem('lessorId')
var categoryId=localStorage.getItem('categoryId')

console.log('added booking ',"https://localhost:7253/api/v1/Boat/lessorId/"+ lessorId +"/categoryId/"+ categoryId );

var requestOptions = {
  method: 'GET',
  redirect: 'follow'
};

fetch("https://localhost:7253/api/v1/Boat/lessorId/"+ lessorId +"/categoryId/"+ categoryId , requestOptions)
  .then(response => response.json())
  .then(result => {
   console.log(result)
           this.boats = result.map(it => it.number);
        
  })
  .catch(error => console.log('error', error));
}
    
   }
   
</script>