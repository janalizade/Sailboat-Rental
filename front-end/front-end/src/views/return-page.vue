<template>
  <v-card
    class="mx-auto"
    max-width="800"
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
                        <v-list-item-content>
                        <v-list-item-title v-text="item.handoverDate"></v-list-item-title>
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
      
         <v-dialog
      v-model="dialog"
      width="500"
    >
      <template v-slot:activator="{ on }">
        <v-btn
          color="red lighten-2"
          dark
          v-on="on"
          v-if="item.title" 
          @click="selectedItem(item, $event)"
        >
          Calculated Price
        </v-btn>
      </template>

      <v-card>
        <v-card-title
          class="headline grey lighten-2"
          primary-title
        >
          Calculated Price
        </v-card-title>

        <v-card-text>
          {{price}}
        </v-card-text>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn
            color="primary"
            flat
            @click="returnPage"
          >
            Return
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <v-divider v-if="item.title" ></v-divider>
        <v-list-item-content>
          <v-list-item-title v-text="item.title"     v-if="item.title"></v-list-item-title>
        </v-list-item-content>

         <v-list-item-content>
          <v-list-item-title v-text="item.handoverDate"     v-if="item.title"></v-list-item-title>
        </v-list-item-content>
        
        <v-list-item-avatar>
          <v-img :src="item.avatar" v-if="item.title"></v-img>
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
          dialog: false,
          price:'',
        result:[],
        items: [
          { icon: true, title: '',handoverDate:'',bookingId:'', avatar:SailBoat  },
          { title: '',handoverDate:'',bookingId:'', avatar: oyster432 },
          { title: '',handoverDate:'',bookingId:'', avatar: oyster595},
          { title: '',handoverDate:'',bookingId:'', avatar: oyster595 },
        ],
      }
    },
    
  methods: {
   returnPage(){
    this.dialog=false;
     this.$router.replace('/');
    },
    selectedItem(item){
        console.log(item.bookingId);
        var requestOptions = {
          method: 'POST',
          redirect: 'follow'
        };

        fetch("https://localhost:7253/api/v1/Booking/lessors/"+localStorage.getItem('lessorId')+"/bookings/"+item.bookingId, requestOptions)
          .then(response => response.json())
          .then(result => {
           //  const price =result.map(it => it.price);
            this.price=result.price;
            console.log(result.price)
           
            })

            
          
          .catch(error => console.log('error', error));
        
    },
    async getData() {
    var requestOptions = {
    method: 'GET',
    redirect: 'follow'
  };

  fetch("https://localhost:7253/api/v1/Booking/lessors/"+localStorage.getItem('lessorId'), requestOptions)
    .then(response => response.json())
    .then(result => {
            this.result=result 
             const titles =this.result.map(it => it.personNumber);
             const handoverDate =this.result.map(it => it.handoverDate);
             const bookingId =this.result.map(it => it.id);
   
               let i=0;
              this.items.forEach(it=>{
                it.title=titles[i];
                it.handoverDate=handoverDate[i];
                it.bookingId=bookingId[i]; 
                 console.log(it)
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

