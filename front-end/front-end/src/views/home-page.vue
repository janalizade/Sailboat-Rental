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
        <v-app-bar-nav-icon> </v-app-bar-nav-icon>
      
        <v-spacer></v-spacer>

       <v-toolbar-items>
          
            <v-menu :rounded="rounded" open-on-hover offset-y transition="slide-x-transition" bottom right>
                <template v-slot:activator="{ on, attrs }">
                    <v-btn flat v-bind="attrs" v-on="on">
                        Services
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
          <v-card>
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

              <v-btn icon>
                <v-icon>mdi-heart</v-icon>
              </v-btn>

              <v-btn icon>
                <v-icon>mdi-bookmark</v-icon>
              </v-btn>

              <v-btn icon>
                <v-icon>mdi-share-variant</v-icon>
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
      titles:{},
      categories:[],
      cards: [
        { title: '', src: SailBoat, flex: 12 },
        { title: '', src: oyster595, flex: 6 },
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
        services: [{
                icon: "mdi-domain",
                title: "Lessor",
                link: "/mmrservices"
            },
            {
                icon: "mdi-message-text",
                title: "Category",
                link: "/createCategory"
            },
            {
                icon: "mdi-message-text",
                title: "Boat",
                link: "/createBoat"
            }
        ]
    }
    },
  
  methods: {
    async getData() {
    var requestOptions = {
    method: 'GET',
    redirect: 'follow'
  };

  fetch("https://localhost:7253/api/Category/", requestOptions)
    .then(response => response.json())
    .then(result => {
      
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
    this.getData();
 
      
  },
   computed: {
 
    
   }
  
  }

</script>
