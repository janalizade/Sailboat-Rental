<template>
  <v-card
    class="mx-auto"
    max-width="500"
  >
    <v-system-bar
      color="indigo darken-2"
      dark
    >
      <v-spacer></v-spacer>

      <v-icon>mdi-window-minimize</v-icon>

      <v-icon>mdi-window-maximize</v-icon>

      <v-icon>mdi-close</v-icon>
    </v-system-bar>


 <v-toolbar rounded tile>
      
      
        <v-spacer></v-spacer>

       <v-toolbar-items>
        
     
            <v-menu :rounded="rounded" open-on-hover offset-y transition="slide-x-transition" bottom right>
                <template v-slot:activator="{ on, attrs }">
                    <v-btn  style="font-size:12px" color="blue-grey" flat v-bind="attrs" v-on="on">
                       {{lessorName}}    Services
                    </v-btn>
                </template>
                <v-list dense>
                    <v-list-item v-for="(item, index) in services" :key="index" router :to="item.link">
                       <v-list-item-action>
                            <v-list-item-title>{{ item.title }}</v-list-item-title>
                        </v-list-item-action>
                    </v-list-item>
                </v-list>
            </v-menu>
             
       
        </v-toolbar-items>
    
        <v-menu open-on-hover transition="slide-x-transition" bottom right offset-y>
            <template v-slot:activator="{ on, attrs }">
                <v-btn icon v-bind="attrs" v-on="on">
                    <v-icon>mdi-dots-vertical</v-icon>
                </v-btn>
            </template>
            <v-card class="mx-auto" max-width="300" tile>
                <v-list dense>
                    <v-subheader>THEMES</v-subheader>
                    <v-list-item-group v-model="theme" color="primary">
                        <v-list-item v-for="(item, i) in themes" :key="i" router :to="item.link">
                            <v-list-item-action>
                                <v-icon v-text="item.icon"></v-icon>
                            </v-list-item-action>
                            <v-list-item-action>
                                <v-list-item-title v-text="item.text"></v-list-item-title>
                            </v-list-item-action>
                        </v-list-item>
                    </v-list-item-group>
                </v-list>
            </v-card>
        </v-menu>
 </v-toolbar>

    <v-container fluid>
      <v-row dense>
        <v-col
          v-for="card in cards"
          :key="card.title"
          :cols="card.flex"
        >
          <v-card v-if="card.title">
            <v-img
              :src="card.src"
              class="white--text align-end"
              gradient="to bottom, rgba(0,0,0,.1), rgba(0,0,0,.5)"
              height="200px"
            >
              <v-card-title v-text="card.title"></v-card-title>
            </v-img>

            <v-card-actions>
              <v-spacer></v-spacer>
           
                  <v-btn
                    class="ml-2 mt-5"
                    color="blue-grey"
                    outlined
                    rounded
                    small
                   @click="bookingPage(card.title)" 
                  >
                    BOOKING
                  </v-btn>
                
                     <v-btn
                    class="ml-2 mt-5"
                    color="blue-grey"
                    outlined
                    rounded
                    small
                   @click="createBoatPage()"
                  >
                    Add Boat
                  </v-btn>
            
            </v-card-actions>
            
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </v-card>
</template>
<script>

import SailBoat from '../../src/assets/img/item_10.webp';
import oyster595 from '../../src/assets/img/Oyster-Yachts.jpg';
import oyster432 from '../../src/assets/img/Oyster-Yachts1.webp';

  export default {
    data() {
     return {
      show: false,
      lessorName:'',
      titles:{},
      categories:[],
      cards: [
        { title: '', src: SailBoat, flex: 12 },
        { title: '', src: oyster595, flex: 6 },
        { title: '', src: oyster432, flex: 6 },
        { title: '', src: oyster432, flex: 6 },
        { title: '', src: oyster432, flex: 6 },
        { title: '', src: oyster432, flex: 6 },
     
      ],


        theme: 1,
        themes: [{
                text: "Dark",
                icon: "mdi-clock"
            },
            {
                text: "Light",
                icon: "mdi-account"
            }
        ],
        mini: true,
        services: [
            {
                icon: "mdi-message-text",
                title: "Category",
                link: "/createCategory"
            }
        ]
    }
    },
  
  methods: {
   bookingPage(x){
    console.log(x)
    console.log(this.categories)
     var item=this.categories.filter(it=>(it.categoryName==x));
    
    console.log('^^^^^',item[0].categoryId)
    localStorage.setItem('categoryId',item[0].categoryId);
     this.$router.replace('/booking');
  },

   createBoatPage(){
     this.$router.replace('/createBoat');
  },
    async getData() {
      
    var requestOptions = {
    method: 'GET',
    redirect: 'follow'
  };

  fetch("https://localhost:7253/api/v1/Category/lessorId/"+localStorage.getItem('lessorId'), requestOptions)
    .then(response => response.json())
    .then(result => {
      console.log('category result',result)
      this.categories=result;       
       const titles =this.categories.map(it => it.categoryName);
       let i=0;
       this.cards.forEach(it=>{
        it.title=titles[i];
        i++
       })       
          
       })

    .catch(error => console.log('error', error));
      },
    },

  created() {
    this.lessorName=localStorage.getItem('lessorName');
    this.getData();
 
      
  },
   computed: {
 
    
   }
  
  }

</script>
