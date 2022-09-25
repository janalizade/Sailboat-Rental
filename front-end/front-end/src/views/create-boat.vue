<template>
   <v-app >
      <v-main>
         <v-container fluid fill-height>
            <v-layout align-center justify-center>
               <v-flex xs12 sm8 md4>
                  <v-card class="elevation-12">
                     <v-toolbar dark color="primary">
                        <v-toolbar-title>New Boat </v-toolbar-title>
                     </v-toolbar>
                     <v-card-text>
                     <form ref="form" @submit.prevent="createBoat()">
                            <v-text-field
                              v-model="number"
                              name="number"
                              label="boat Number"
                              type="text"
                              placeholder="Boat Number"
                              required
                           ></v-text-field>

                         
                            <div style= "display:flex">
                              <v-btn type="submit" color="orange"    text  value="submit">Create</v-btn>
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
       number: "",
       categoryId: "",
       lessorId: ""
      
    };
  },
  methods: {
    returnCategoryPage(){
     this.$router.replace('/category');
    },
    createBoat() {
    
      var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        var raw = JSON.stringify({
         number: this.number,
         categoryid: this.categoryId,
         lassorid: this.lessorId
        });

        var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
        };
            
         var lessorId=localStorage.getItem('lessorId');
         var categoryId=localStorage.getItem('categoryId');
       
        fetch("https://localhost:7253/api/v1/Boat/lessorId/"+ lessorId +"/categoryId/"+ categoryId , requestOptions)
       // fetch("https://localhost:7253/api/v1/Boat/lessorId/"+localStorage.getItem('lessorId'), requestOptions)
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.log('error', error));
            },
        },
        };
</script>