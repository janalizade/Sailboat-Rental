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
                           <v-btn type="submit" class="mt-4" color="primary" value="submit">Create</v-btn>
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
    };
  },
  methods: {
    createCategory() {
    
      var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        var raw = JSON.stringify({
        "categoryName": this.categoryName,
        "description":this.description
        });

        var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
        };

        fetch("https://localhost:7253/api/category", requestOptions)
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.log('error', error));
            },
        },
        };
</script>