<template>
   <v-app >
      <v-main>
         <v-container fluid fill-height>
            <v-layout align-center justify-center>
               <v-flex xs12 sm8 md4>
                  <v-card class="elevation-12">
                     <v-toolbar dark color="primary">
                        <v-toolbar-title>New Category </v-toolbar-title>
                     </v-toolbar>
                     <v-card-text>
                     <form ref="form" @submit.prevent="createCategory()">
                            <v-text-field
                              v-model="categoryName"
                              name="categoryName"
                              label="Category Name"
                              type="text"
                              placeholder="Category Name"
                              required
                           ></v-text-field>
                           
                            <v-text-field
                              v-model="description"
                              name="description"
                              label="Category description"
                              type="text"
                              placeholder="password"
                              required
                           ></v-text-field>

                            <v-text-field
                              type="number"   
                              step="any"
                              min="0"
                              ref="input"
                              label="Basic Fee"
                              suffix="kr"
                              :rules="[numberRule]"
                              v-model.number="basicFee"
                           ></v-text-field>
                           
                             <v-text-field
                              type="number"   
                              step="any"
                              min="0"
                              suffix="kr"
                              ref="input"
                              :rules="[numberRule]"
                              v-model.number="hourlyRate"
                              label="Hourly Rate"
                           ></v-text-field>
                            <div style= "display:flex">
                                <v-btn type="submit" color="orange"    text  value="submit">Create</v-btn>
                                <v-btn   color="orange"  text  @click="returnCategoryPage()" > CATEGORY PAGE    </v-btn>               
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
      categoryName: "",
      description: "",
      basicFee: 0,
      hourlyRate:0,
      numberRule: val => {
      if(val < 0) return 'Please enter a positive number'
      return true
    }
    };
  },
  methods: {
    returnCategoryPage(){
     this.$router.replace('/category');
   },

    createCategory() {
    
      var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        var raw = JSON.stringify({
        "categoryName": this.categoryName,
        "description":this.description,
        "basicFee":this.basicFee,
        "hourlyRate":this.hourlyRate

        });
      
        var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
        };
 


        fetch("https://localhost:7253/api/v1/category/lessorId/"+localStorage.getItem('lessorId'), requestOptions)
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.log('error', error));
            },
        },
        };
</script>