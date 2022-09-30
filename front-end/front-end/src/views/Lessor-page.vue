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
           
        </v-menu>
 </v-toolbar>

    <v-container>
      <v-row dense>
        <v-col cols="12">
          
        </v-col>

        <v-col
          v-for="(item, i) in items"
          :key="i"
          cols="12"
        >
          <v-card
            :color="item.color"
            dark
            v-if="item.title"
          >
            <div class="d-flex flex-no-wrap justify-space-between">
              <div>
                <v-card-title
                  class="text-h5"
                  v-text="item.title"
                ></v-card-title>

                <v-card-subtitle v-text="item.address"></v-card-subtitle>

                <v-card-actions>
                  <v-btn
                    class="ml-2 mt-5"
                    outlined
                    rounded
                    small
                    @click="selectedLessor(item, $event)"
                  >
                    START BOOKING
                  </v-btn>
                   <v-btn
                    class="ml-2 mt-5"
                    outlined
                    rounded
                    small
                    @click="returnPage(item, $event)"
                  >
                    RETURN BOAT
                  </v-btn>
                </v-card-actions>
              </div>

              <v-avatar
                class="ma-3"
                size="125"
                tile>
                <v-img :src="item.src"></v-img>
              </v-avatar>
            </div>
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

    
    data: () => ({
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
                link: "/createLessor"
            },
            
        ],
        lessors:[],
        titles:[],
     items: [
        { title: '', address:'', src: SailBoat, color:'#1F7087' },
        { title: '', address:'',src: oyster595, color: '#952175'  },
        { title: '', address:'',src: oyster432,  color: '#1F7087'},
        { title: '', address:'',src: oyster595,  color: '#952175'},
        { title: '', address:'',src: SailBoat,  color: '#1F7087'},
        { title: '', address:'',src: oyster432,  color: '#952175'},
        { title: '', address:'',src: SailBoat,  color: '#1F7087'},
      ],
    
    }),

    
  
  methods: {
      returnPage(item){
      const selectedItem=this.lessors.find(it=>it.name===item.title);
      localStorage.setItem('lessorName',selectedItem.name)
      localStorage.setItem('lessorId',selectedItem.id);
      console.log('lessorId',localStorage.getItem('lessorId'));
     this.$router.replace('/returnPage');
    },
    selectedLessor(item){
        console.log(item.title);
        const selectedItem=this.lessors.find(it=>it.name===item.title);
        localStorage.setItem('lessorName',selectedItem.name)
        localStorage.setItem('lessorId',selectedItem.id);
         console.log('lessorId',localStorage.getItem('lessorId'));
         this.$router.replace('/category');
        console.log(localStorage.getItem('lessorName'));
    },
    async getData() {
    var requestOptions = {
    method: 'GET',
    redirect: 'follow'
  };

  fetch("https://localhost:7253/api/v1/Lessor/", requestOptions)
    .then(response => response.json())
    .then(result => {
       this.lessors=result;       
       console.log(result)
       const titles =this.lessors.map(it => it.name);
       const address=this.lessors.map(it => it.address);
       let i=0;
       this.items.forEach(it=>{
        it.title=titles[i];
        it.address=address[i];
        i++
       }) 
    })

    .catch(error => console.log('error', error));
      }      
    },
    created() {
    this.getData();
    
  },
  }
</script>