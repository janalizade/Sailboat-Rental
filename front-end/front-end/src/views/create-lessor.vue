<template>
   <v-app >
      <v-main>
         <v-container fluid fill-height>
            <v-layout align-center justify-center>
               <v-flex xs12 sm8 md4>
                  <v-card class="elevation-12">
                     <v-toolbar dark color="primary">
                        <v-toolbar-title>New Lessor </v-toolbar-title>
                     </v-toolbar>
                     <v-card-text>
                     <form ref="form" @submit.prevent="createLessor()">
                            <v-text-field
                              v-model="lessorName"
                              name="lessorName"
                              label="Lessor Name"
                              type="text"
                              placeholder="Lessor Name"
                              required
                           ></v-text-field>
                           
                            <v-text-field
                              v-model="address"
                              name="address"
                              label="Lessor Address"
                              type="text"
                              placeholder="address"
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
      lessorName: "",
      addresss: "",
    };
  },
  methods: {
    createLessor() {
    
      var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/json");

        var raw = JSON.stringify({
        "name": this.lessorName,
        "address":this.address
        });

        var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
        };

        fetch("https://localhost:7253/api/lessor", requestOptions)
        .then(response => response.json())
        .then(result => console.log(result))
        .catch(error => console.log('error', error));
            },
        },
        };
</script>