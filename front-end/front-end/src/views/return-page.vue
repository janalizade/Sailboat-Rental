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
         <v-toolbar-title>Return Boat </v-toolbar-title>
      
        <v-spacer></v-spacer>

       <v-toolbar-items>
        
     
         
       
        </v-toolbar-items>
    
        <v-menu open-on-hover transition="slide-x-transition" bottom right offset-y>
            <template v-slot:activator="{ on, attrs }">
                <v-btn icon v-bind="attrs" v-on="on">
                    <v-icon>mdi-dots-vertical</v-icon>
                </v-btn>
            </template>
            <v-card class="mx-auto" max-width="300" tile>
               <v-list>
                    <v-list-item
                        v-for="item in items"
                        :key="item.title"
                    
                    >
                        <v-list-item-icon>
                        <v-icon v-if="item.icon" color="pink">mdi-star</v-icon>
                        </v-list-item-icon>

                        <v-list-item-content>
                        <v-list-item-title v-text="item.title"></v-list-item-title>
                        </v-list-item-content>

                        <v-list-item-avatar>
                        <v-img :src="item.avatar"></v-img>
                        </v-list-item-avatar>
                    </v-list-item>
                    </v-list>
            </v-card>
        </v-menu>
 </v-toolbar>
    <v-list>
      <v-list-item
        v-for="item in items"
        :key="item.title"
     
      >
        <v-list-item-icon>
          <v-icon v-if="item.icon" color="pink">mdi-star</v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title v-text="item.title"></v-list-item-title>
        </v-list-item-content>

        <v-list-item-avatar>
          <v-img :src="item.avatar"></v-img>
        </v-list-item-avatar>
      </v-list-item>
    </v-list>
  </v-card>
</template>

<script>
import SailBoat from '../../src/assets/img/item_10.webp';
import oyster595 from '../../src/assets/img/Oyster-Yachts.jpg';
import oyster432 from '../../src/assets/img/Oyster-Yachts1.webp';
  export default {
    data () {
      return {
        items: [
          { icon: true, title: 'Jason Oner', avatar:SailBoat  },
          { title: 'Travis Howard', avatar: oyster432 },
          { title: 'Ali Connors', avatar: oyster595},
          { title: 'Cindy Baker', avatar: oyster595 },
        ],
      }
    },
    methods:{
   
    }
  }
</script>


