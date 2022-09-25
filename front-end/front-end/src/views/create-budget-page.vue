<template>
  <v-container fluid class="main-container disable-double-tap-zoom" @click="toggleInactivity()">

    <v-card style="background-color:#e7f3f3">

      <div align="center" justify="center" style="position: relative;" class="hidden-sm-and-down">

        <div class="create-page-title-wrap">
          Skapa budget
        </div>

        <p class="budget-comment mt-5">
          För att kunna köpa det du behöver, eller kanske vill ha, är det viktigt att veta vad som är lagom för dig. Genom att fylla i uppgifterna nedanand alig
          så kan du hitta ditt alldeles egna, ekonomiska lagom i form av en budget. Så att du kan leva som du vill leva, och ha råd med det. Då är lagom bäst.
        </p>

      </div>

      <div align="center" justify="center" style="position: relative;" >

        <div class="create-page-title-wrap-xs" >
          Personlig budget
        </div>

        <div>
          <v-card class="mx-auto elevation-10 my-12" max-width="90%" style="border-radius: 20px 20px 20px 20px;">
            <v-col style="margin-top: 16px; margin-left: 25px; margin-right: 106px; padding-bottom: 63px;">

              <v-row>
                <div class="budget-title mt-3">
                  Din budget
                </div>
              </v-row>

              <v-row>
                <div :class="[$vuetify.breakpoint.smAndDown?'header-budget-comment-xs':'header-budget-comment']" align="left">
                  Du har en bra kontroll över dina inköp, och du har en del pengar kvar i slutet av månaden – toppen!
                </div>
              </v-row>

              <v-row>
                <div class="d-flex mt-3" style="font-weight: 600; font-size: 16px; line-height: 16px; color: #868686;" >

                  <v-col>

                    <div class="d-flex">

                      <div>
                        Din inkomst
                        <v-tooltip top>

                          <template v-slot:activator="{ on,attrs }">
                            <v-icon v-bind="attrs" v-on="on" class="material-icons hidden-xs-only" color="grey" dark style="padding-top: 2px;font-size:13px;padding-left:5px" >
                              mdi-information-outline
                            </v-icon>
                          </template>

                          <div>
                            din inkomst efter skatt i värje månad
                          </div>

                        </v-tooltip>
                      </div>

                      <div v-if="selectedTab === 2 " :class="[$vuetify.breakpoint.xsOnly?'overview-items-xs':'overview-items']" class="ml-11 ">

                         <input
                          id="input"
                          v-model.number="redigera.inkomst"
                          style="padding-left:10px;padding-right:10px;width: 90px; color: #868686;"
                          class="no-outline"
                          maxlength="10"
                          :rules="[rules.required, rules.counter, rules.input]"
                          :disabled="selectedTab === 0 ? true : false"
                        />
                        kr
                      </div>

                    </div>

                    <div v-if="selectedTab===2" class="mt-1 mb-4">
                      <v-slider
                        track-color="#addad9"
                        thumb-color="#addad9"
                        color="#addad9"
                        always-dirty
                        class="alektum-slider"
                        v-model="redigera.inkomst"
                        :max="redigera.maxInkomst"
                        :class="[$vuetify.breakpoint.xsOnly?'expenses-slideBar-xs':'expenses-slideBar']"
                        style="float: unset;">

                        <template v-slot:prepend>
                          <v-btn fab dark x-small color="#addad9" @click="redigera.inkomst = redigera.inkomst - 3; $forceUpdate();">
                            <v-icon dark>
                              mdi-minus
                            </v-icon>
                          </v-btn>
                        </template>

                        <template v-slot:append>
                          <v-btn fab dark x-small color="#addad9" @click="redigera.inkomst = redigera.inkomst + 3; $forceUpdate();">
                            <v-icon dark>
                              mdi-plus
                            </v-icon>
                          </v-btn>
                        </template>

                      </v-slider>
                    </div>

                  </v-col>

                   <div v-if="selectedTab===0" class="mt-2 ml-11">
                    <div v-if="inkomstPerMonth.length > 0" class="overview-items">
                      {{ inkomstPerMonth[inkomstPerMonth.length - 1].income.toFixed(0) }} kr
                    </div>
                  </div>

                </div>
              </v-row>

              <v-row v-if="selectedTab === 1" class="mt-1">
                <div>
                  <graph-details
                    :width="[$vuetify.breakpoint.xsOnly?'300':'410']"
                    :height="[$vuetify.breakpoint.xsOnly?'150':'180']"
                    :categories="inkomstPerMonth.map(it => it.month)"
                    :values="inkomstPerMonth.map(it => Math.trunc(it.income))"
                  />
                </div>
              </v-row>

              <v-row class="mt-4">
                <div class="d-flex flex-row align-center justify-space-between header-budget-comment" style="font-weight: 600; font-size: 16px; line-height: 26px; color: #868686;">

                  <div>
                    Kvar att leva på
                    <v-tooltip top>
                      <template v-slot:activator="{ on,attrs }">
                        <v-icon v-bind="attrs" v-on="on" class="material-icons hidden-xs-only" color="grey"  dark  style="padding-top: 2px;font-size:13px;padding-left:5px" >
                          mdi-information-outline
                        </v-icon>
                      </template>
                      <div>
                        pengar kvar i värje månad
                      </div>
                    </v-tooltip>
                  </div>

                   <div v-if="selectedTab === 0" style="margin-left:24px;padding-left:20px;">
                    <div v-if="minRemainingPerMonth.length > 0" class="overview-items">
                      {{ minRemainingPerMonth[minRemainingPerMonth.length - 1].remaining.toFixed(0) }} kr
                    </div>
                  </div>

                  <div v-if="selectedTab === 2 " style="margin-left:24px;padding-left:20px;">
                    <div v-if="redigeraCurrentKevar>0" class="overview-items">

                      {{ redigeraCurrentKevar.toFixed(0) }} kr
                    </div>
                    <div v-else >
                       {{0}}
                    </div>
                  </div>

                </div>
              </v-row>

              <v-row>
                <div v-if="selectedTab === 1" class="mt-1 ">
                  <graph-details
                    :width="[$vuetify.breakpoint.xsOnly?'300':'400']"
                    :height="[$vuetify.breakpoint.xsOnly?'150':'180']"
                    :categories="minRemainingPerMonth.map(it => it.month)"
                    :values="minRemainingPerMonth.map(it => Math.trunc(it.remaining) )"
                  />
                </div>
              </v-row>

            </v-col>
          </v-card>
        </div>

      </div>

      <div style="padding-bottom: 24px">
        <v-card class="mx-auto elevation-10 my-12" max-width="90%" style="border-radius: 20px 20px 20px 20px; background-color: #F7FBFB;">
          <v-row >

            <v-col md="12">
              <v-tabs v-model="selectedTab" style="margin-top: 26px;" grow color="#f8b68d" background-color="#F7FBFB" show-arrows>

                <v-tab name="oversikt" class="v-tabs-style">
                  Översikt
                </v-tab>

                <v-tab name="details" class="v-tabs-style">
                  Detaljer
                </v-tab>

                <v-tab name="edit" class="v-tabs-style">
                  Redigera
                </v-tab>

                <v-tab-item>
                  <v-card  style="background-color: #F7FBFB; border-radius: 30px 30px 30px 30px; ">

                    <v-divider  horizontal />

                    <v-row class=" mt-8 pb-11">
                      <v-col v-for="category in expensesCategories" :key="category.id" md="5" sm="12" >

                           <div class="d-flex flex-row" :class="[$vuetify.breakpoint.xsOnly?'expenses-table-wrap-xs' :'expenses-table-wrap']" >
                          <img class="mt-2" :src="category.image" outlined style="width: 40px; height: 40px; border-radius: 0px;"/>

                            <div class="overview-title" style="padding-left: 25px; float: right">
                              {{ category.name }}

                              <v-tooltip top fixed >
                                <template v-slot:activator="{ on,attrs }" >
                                  <v-icon v-bind="attrs" v-on="on" class="material-icons hidden-xs-only" color="grey"  dark  style="font-size:13px;padding-left:3px" >
                                    mdi-information-outline
                                  </v-icon>

                                </template>
                                <p>
                                  {{category.hint}}
                                </p>
                              </v-tooltip>

                              <div style="font-family: 'Barlow';font-weight: 800;font-size: 20px;line-height: 24px;">
                               {{ category.lastSpend.toFixed(0) }} kr
                              </div>
                            </div>
                        </div>
                      </v-col>
                    </v-row>

                  </v-card>
                </v-tab-item>

                <v-tab-item>
                  <v-card flat style="background: #F7FBFB; border-radius: 30px 30px 30px 30px;">

                    <v-divider horizontal />

                    <v-row class="mt-8 pb-11" >
                      <v-col v-for="category of expensesCategories" :key="category.id" cols="12" md="5" sm="12" no-gutters outlined>

                        <div class="d-flex flex-row" :class="[$vuetify.breakpoint.xsOnly?'expenses-table-wrap-xs' :'expenses-table-wrap']" >

                          <img :src="category.image" outlined style="width: 40px; height: 40px; border-radius: 0px;"/>

                          <div class="overview-title" style="padding-top:8px;padding-left:12px;float:left">
                            {{ category.name }}
                          </div>
                          <div style="float:right">
                              <v-tooltip top>
                                <template v-slot:activator="{ on,attrs }">
                                  <v-icon v-bind="attrs" v-on="on" class="material-icons hidden-xs-only" color="grey"  dark  style="padding-top:7px;font-size:13px;padding-left:5px" >
                                    mdi-information-outline
                                  </v-icon>
                                </template>
                                <p>
                                  {{category.hint}}
                                </p>
                              </v-tooltip>
                          </div>
                        </div>

                        <div  :class="[$vuetify.breakpoint.xsOnly?'expenses-table-wrap-xs' :'expenses-table-wrap']">
                          <graphDetails
                            :label="category.name"
                            class="mt-n4"
                            :categories="category.spendPerMonth.map(it => it.month)"
                            :values="category.spendPerMonth.map(it => Math.trunc(it.spend))"
                            :width="[$vuetify.breakpoint.xsOnly?'300':'400']"
                            :height="[$vuetify.breakpoint.xsOnly?'150':'180']"
                          />
                        </div>

                      </v-col>
                    </v-row>
                  </v-card>
                </v-tab-item>

                <v-tab-item>
                     <v-card style="background-color: #F7FBFB; border-radius: 30px 30px 30px 30px;mt-5">

                    <v-divider  horizontal />

                    <v-row class="mt-8 pb-11" >
                      <v-col v-for="category in redigera.categories" :key="category.id" md="5" sm="12" >
                        <div class="d-flex flex-row" :class="[$vuetify.breakpoint.xsOnly?'expenses-table-wrap-xs' :'expenses-table-wrap']" >

                          <img class="mt-2" :src="category.image" outlined style="width: 40px; height: 40px; border-radius: 0px;"/>
                            <div class="edit-title" >
                              {{ category.name }}

                              <div :class="[$vuetify.breakpoint.xsOnly?'expense-input-wrap-xs':'expense-input-wrap']"  >
                               <input
                                   class="no-outline"
                                    style='width:120px;'
                                    width="100"
                                    type="number"
                                    v-model.number="category.lastSpend"
                                  />
                                 <span>KR</span>
                              </div>
                            </div>
                        </div>
                        <v-row>
                         <div class="hidden-xs-only" style="margin-left:100px;padding-bottom:15px ;padding-top:4px ;">
                            <v-slider
                              track-color="#addad9"
                              thumb-color="#addad9"
                              color="#addad9"
                              always-dirty
                              :class="[$vuetify.breakpoint.xsOnly?'expenses-slideBar-xs':'expenses-slideBar']"
                              class="alektum-slider"
                              @change="showWallet = !showWallet"
                              v-model="category.lastSpend"
                              :max="Math.max(category.maxSpend, category.lastSpend)"
                              style="float: left;">
                              <template v-slot:prepend>
                                <v-btn  fab dark x-small color="#addad9"  @click="category.lastSpend = category.lastSpend - 3; $forceUpdate();">
                                  <v-icon dark>
                                    mdi-minus
                                  </v-icon>
                                </v-btn>
                              </template>
                              <template v-slot:append>
                                <v-btn fab dark x-small color="#addad9" @click="category.lastSpend = category.lastSpend + 3; $forceUpdate();">
                                  <v-icon dark>
                                    mdi-plus
                                  </v-icon>
                                </v-btn>
                              </template>
                            </v-slider>
                         </div>
                        </v-row>

                      </v-col>
                    </v-row>

                  </v-card>

                </v-tab-item>

              </v-tabs>
            </v-col>

          </v-row>
        </v-card>
      </div>

    </v-card>

    <description />

    <v-dialog v-if="showInactiveDialog" :value="true" persistent width="512">
      <v-card flat>

        <v-card-title>
          <v-icon class="me-3">
            mdi-clock-alert
          </v-icon>
          Session timeout warning!
        </v-card-title>

        <v-card-text>
          Din session kommer att avslutas inom kort. Vänligen bekräfta nedan om du vill förtsätta behålla sessionen.
        </v-card-text>

        <v-card-actions>
          <v-btn depressed color="primary" block rounded large @click="resetRejectionTimer()">
            ok!
          </v-btn>
        </v-card-actions>

      </v-card>
    </v-dialog>

    <v-dialog v-if="isReachData" :value="true" persistent width="512">
      <v-card flat>

        <v-card-title>
          <v-icon class="me-3">
            mdi-clock-alert
          </v-icon>
          Opss! Nåt verkar ha gått fel
        </v-card-title>

        <v-card-text>
          Dessvärre fick vi ingen information från din bank.Vill du prova igen eller välja en annan bank?
        </v-card-text>

        <v-card-actions class="pt-0">
     

          <v-btn color="primary darken-1" text @click="isTransactionSucceed()">
            Yes
          </v-btn>

          <v-btn color="primary darken-1" text @click="transferHome()">
            No
          </v-btn>

        </v-card-actions>

      </v-card>
    </v-dialog>

  </v-container>
</template>

<script>

import description from '../components/description.vue'
import graphDetails from '../components/graph-details.vue'
import sum from 'lodash/sum';
import axios from 'axios';
// import MockData from '../data/maryam.json';


export default {
  components: {
    description,
    graphDetails
  },
  data() {
    return {
      isReachData:false,
      selectedTab:null,
      portfolios:['2.svg','3.svg','4.svg'],
      loading: false,
      rules: {
        required: (value) => !!value || "Required.",
        counter: (value) => (value !== undefined && value.length <= 12) || "Max 20 characters",
      },
      showWallet:false,
      itemsShowed: [],
      interval: null,
      month: null,
      isAccountList: true,
      showAccountDetails: false,
      bufferValue: 20,
      allowKey: ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "Backspace"],
      bankIdDialog: false,
      showHint: false,
      tab: null,
      apiData: null,
      isGraph: false,
      json: '',
      x: 0,
      isSlideNumber: 'slideRadio',
      total:0,
      expensesCategories: [
        {
          id: 0,
          name: 'Boende',
          nordigenCategoryId: '17',
          tinkCategoryIds: [],
          image: require('../assets/img/utgifter/BOENDE.png'),
          spendTotal: 0,
          lastSpend: 0,
          originalSpend: 0,
          maxSpend: 30000,
          incomeTotal: 0,
          lastIncome: 0,
          spendPerMonth: [],
          incomePerMonth: [],
          hint: 'Här fyller du i dina boendekostnader, exempelvis din hyra för lägenheten eller lånekostnader för huset.',
        },
        {
          id: 1,
          name: 'Överföringar',
          nordigenCategoryId: '7',
          tinkCategoryIds: [
          '6b533f25052e4f64be2ef042f7a95f28',
          '76dabde5ce1349b49d8f48480a55a545',
          'bba1bed16c564a908882301e62434b69',
          'bcd8706e1a7c49899b72851662e292f2',
          'd8f37f7d19c240abb4ef5d5dbebae4ef'
          ],
          image: require('../assets/img/utgifter/Money transfer.png'),
          spendTotal: 0,
          lastSpend: 0,
          originalSpend: 0,
          maxSpend: 50000,
          incomeTotal: 0,
          lastIncome: 0,
          spendPerMonth: [],
          incomePerMonth: [],
          hint: 'Här fyller du i överföringarkostnader per månad.',
          message: 'Är du säker på att du behöver spendera så mycket på hushåll?',
        },
        {
          id: 2,
          name: 'Hushåll',
          nordigenCategoryId: '9',
          tinkCategoryIds: [
            '01f944531ab04cd3ba32a14cebe8a927',
            '075fab3ec31f43aa9d39675475c1fb1a',
            '25a34f372da14b9a8bf230f15de1a928',
            '2f8c67f8ac90485186b9acf7b1afe6a3',
            '3b52969658164d30930f51a2965ecc65',
            '6dc2aec9874047ed860f02135db06680',
            '9308a083665741588b88d9160aedf968',
            'adb78e1f35b44f88b5da5ebbefafe25b',
            'ade3d44c4fa64345a75ddaaa73abd9d6',
            'c548dd5a583d4cba8372d0782e037172',
            'e08d76c43e2b469e8333d4ae07793962',
            'f5220586cb184ec38d4b65384a40f91e',
            'f97ed636f1c54f1f91b5c648f9329155'
          ],
          image: require('../assets/img/utgifter/HUSHALL.png'),
          spendTotal: 0,
          lastSpend: 0,
          originalSpend: 0,
          maxSpend: 30000,
          incomeTotal: 0,
          lastIncome: 0,
          spendPerMonth: [],
          incomePerMonth: [],
          hint: 'Borta bra, men hemma bäst. Här fyller du i hushålls-kostnader som exempelvis försäkringar, el, TV, mobil och internet.',
        },
        {
          id: 3,
          name: 'Mat',
          nordigenCategoryId: '4',
          tinkCategoryIds: [
            '3574aa8a22d4480983b9d4c0451c2776',
            'c59a38ff206c4fe29a9e7b2bb1fcb3de',
            'c839cf1715ae459384aaae62353ff463',
            'e572c2027faa4672b259e4adadf9d249'
          ],
          image: require('../assets/img/utgifter/MAT.png'),
          spendTotal: 0,
          lastSpend: 0,
          originalSpend: 0,
          maxSpend: 25000,
          incomeTotal: 0,
          lastIncome: 0,
          spendPerMonth: [],
          incomePerMonth: [],
          hint: 'ätt som en plätt. Här fyller du i dina kostnader för att göra magen nöjd och belåten.',
          message:'Det ser ut som du spenderar mer än genomsnittet på mat. Kanske dags att se över dina matkostnader?'
        },
        {
          id: 4,
          name: 'Nöjen',
          nordigenCategoryId: '3',
          tinkCategoryIds: [
            '049ff3909f4d46fc9cb63a4f9b048ece',
            '07da44eeae8d448b8b67bdf5e0488832',
            '167a4ebe333245faa00f10b62493cdbc',
            '47ea44117c6543178b3fefae8ffada52',
            '63a7e66150d44c67a3380265c86e1c26',
            '869ba69373574b98b0b3f1396f1bf2c3',
            '90c82b2781704763a1c49e236ea20142',
            'a18d9bf1d24b44589726ae811717cb75',
            'aa868f6851224c44901ad302f0a1527c',
            'bde2284069594e3380941026474cbda2',
            'c22e51b7abfa48088fb500005e21df76',

            'f95f30da395348c488261e990e8c0e54'
          ],
          image: require('../assets/img/utgifter/NOJEN.png'),
          spendTotal: 0,
          lastSpend: 0,
          originalSpend: 0,
          maxSpend: 25000,
          incomeTotal: 0,
          lastIncome: 0,
          spendPerMonth: [],
          incomePerMonth: [],
          hint: 'Du måste ju ha lite kul också. Här fyller du i kostnader för exempelvis fikan på stan eller biobesöket med kompisen.'
        },
        {
          id: 5,
          name: 'Transport',
          nordigenCategoryId: '15',
          tinkCategoryIds: [
            '3aa36e08db054422941fec97d2ab33f6',
            '8f30832aaa35480bbd88d683be480769',
            '9bde7aead97448a6954fa87803b83c67',
            'e005b42a480b4cad924db7cfe5300337',
            'ea8bc346e5874b1eaceafa6481e5f901',
            'f418a581e9a54c4a8a459030fc3f5697'
          ],
          image: require('../assets/img/utgifter/TRANSPORT.png'),
          spendTotal: 0,
          lastSpend: 0,
          originalSpend: 0,
          maxSpend: 10000,
          incomeTotal: 0,
          lastIncome: 0,
          spendPerMonth: [],
          incomePerMonth: [],
          hint: 'På resande fot. Här fyller du i dina transportkostnader, exempelvis för det där busskortet eller bensin till bilen.'
        },
        {
          id: 6,
          name: 'Sparande',
          nordigenCategoryId: '10',
          tinkCategoryIds: [
            '420e802515a140b1b2b389b54500784f',
            '4a6f8b8f6acb48c2a47f5b98a61d6f19'
          ],
          image: require('../assets/img/utgifter/SPARANDE.png'),
          spendTotal: 0,
          lastSpend: 0,
          originalSpend: 0,
          maxSpend: 40000,
          incomeTotal: 0,
          lastIncome: 0,
          spendPerMonth: [],
          incomePerMonth: [],
          hint: 'Den som spar, hen har. Här fyller du i hur mycket du lägger i spargrisen varje månad.',
          message:'Glöm inte att 20% av din inkomst bör gå till sparande.'
        },
        {
          id: 7,
          name: 'Shopping',
          nordigenCategoryId: 'Shopping',
          tinkCategoryIds: [
            '0cbe3c0155764a8faba86196dacce1c2',
            '26e47df594f74e7b972935105a91881e',
            '9faddd4c806b48a29301891f6a310c78',
            'a06a29ba01ad4903a0505fb1ba54d2ae',
            'b64f0e4f328a4d00b623b7ca3f588879',
            'ed909bd383f245aabab53d3e3ee8e4bf'
          ],
          image: require('../assets/img/utgifter/SHOPPING.png'),
          spendTotal: 0,
          lastSpend: 0,
          originalSpend: 0,
          maxSpend: 40000,
          incomeTotal: 0,
          lastIncome: 0,
          spendPerMonth: [],
          incomePerMonth: [],
          hint: 'Shoppa Lagom. Här fyller du i dina shopping-kostnader, exempelvis kläder, skor och andra prylar.',
          message:'Glöm inte att ge spargrisen lite pengar också!'
        },
        {
          id: 8,
          name: 'Övrigt',
          nordigenCategoryId: '99',
          tinkCategoryIds: [
            '0217989903af43c5b7b4e66c0515d0d5',
            '15be09f7fe82405da1aa498fa92121fa',
            '3810f797bc394a93ade86232b5d6de9f',
            '4b9c3dc9739b457ab05226e0bc4d6738',
            '5f23014f62cf4cf19ad58f9ac84bbe34',
            '6ddd66c5b7c84bd09c6c68d8b75a4314',
            '99dd6d0c05a347d1858daa219e21c573',
            'b3963cfe6bf54c06b22eaa44e0a6cf3f',
            'd7289138301642b1b927a506292fe610',
            'fb7618bd315248eeaac217fec003f89c'
          ],
          image: require('../assets/img/utgifter/OVRIGT.png'),
          spendTotal: 0,
          lastSpend: 0,
          originalSpend: 0,
          maxSpend: 40000,
          incomeTotal: 0,
          lastIncome: 0,
          spendPerMonth: [],
          incomePerMonth: [],
          hint: 'Annat smått och gott. Här fyller du i dina övriga utgifter som du kan tänkas ha under en månad.'
        },
        {
          id: 9,
          name: 'Hälsa & Skönhet',
          nordigenCategoryId: '5',
          tinkCategoryIds: [
            '4cc474aee3c74473a7ddced5c8703b77',
            'e1aa3343b3d64bd88d17137d9696bcdb',
            '2a399e962e3b4ac49b61ade0f8380840',
            'd5dbacd3bcad4f28b73489926adf46fb',
          ],
          image: require('../assets/img/utgifter/Beauty and spa 1.png'),
          spendTotal: 0,
          lastSpend: 0,
          originalSpend: 0,
          maxSpend: 15000,
          incomeTotal: 0,
          lastIncome: 0,
          spendPerMonth: [],
          incomePerMonth: [],
          hint: 'Annat smått och gott. Här fyller du i dina övriga utgifter som du kan tänkas ha under en månad.',
          message:'Ska man bli fin får man lida pin, men det kanske är dags att se över de här kostnaderna?'
        }
      ],
      inkomstPerMonth: [],
      lastMonthIncomeSum: 0,
      minRemainingPerMonth: [],
      lastMonthSpendSum: 0,
      totalSpend: 0,
      pageSize: 3,
      visiblePages: 7,
      pageNumber: 1,
      offset: 0,
      limit: 0,
      numOfPages: 0,
      paginationSize: 0,
      selected: [],
      i: 0,
      s: 0,
      salaryGraphTitle: 'Inkomst',
      walletValue: [],
      graphItems: [],
      walletSum: 0,
      checkbox: true,
      isBankSelected: false,
      isBankList: false,
      isExpenses: false,
      isIncome: true,
      showInactiveDialog: false,
      inactivityTimerHandle: undefined,
      rejectionTimerHandle: undefined,
      redigera: {
        inkomst: 0,
        maxInkomst: 50000,
        originalInkomst: 0,
        kevarAtLeva: 0,
        originalKevarAtLeva: 0,
        categories: [],
        originalCategoriesSpendSum: 0
      }
    };
  },
  computed: {
    redigeraCurrentKevar() {

      const incomeDelat = this.redigera.inkomst - this.redigera.originalInkomst;
      const spendSumDelta = sum(this.redigera.categories.map(it => it.lastSpend)) - this.redigera.originalCategoriesSpendSum;

      return this.redigera.originalKevarAtLeva + incomeDelat - spendSumDelta;

    }
  },
  mounted() {
    if (this.$route.query.success == 'false') {
      this.isReachData = true;
    }

    this.selectedTab = 'oversikt';
    this.showAccountDetails = false;
    this.isAccountList = true;

    this.getAccountDetails();

    this.resetInactivityTimer();

  },
  beforeDestroy() {
    clearTimeout(this.inactivityTimerHandle);
    clearTimeout(this.rejectionTimerHandle);
  },
  methods: {
    isTransactionSucceed(){
      this.storeUser()
    },
    transferHome(){
      this.$router.replace('/')
    },
    resetInactivityTimer() {

      clearTimeout(this.inactivityTimerHandle);
      this.inactivityTimerHandle = setTimeout(() => {

        this.showInactiveDialog = true;

        this.rejectionTimerHandle = setTimeout(() => {
          localStorage.removeItem('token');
          this.$router.replace('/');
        }, 1 * 60 * 1000);

      }, 4 * 60 * 1000);

    },
    toggleInactivity() {
      if (this.showInactiveDialog) return;
      this.resetInactivityTimer();
    },
    resetRejectionTimer() {
      clearTimeout(this.rejectionTimerHandle);
      this.showInactiveDialog = false;
      this.resetInactivityTimer();
    },
    setItems() {

      this.offset = (this.pageNumber - 1) * this.pageSize;
      this.limit = this.offset + this.pageSize;
      this.numOfPages = Math.ceil(this.values.length / this.pageSize);

      if (this.offset > this.values.length) {
        this.pageNumber = this.numOfPages;
      }

      this.itemsShowed = this.values.slice(this.offset, this.pageSize + this.offset);

    },
    setPage(n) {

      this.pageNumber = n;
      this.setItems();

      return this.itemsShowed;
    },
    async getAccountDetails() {
     const date = new Date()
     const year=date.getFullYear();
     const firstDay = '01';
     const lastDay='30';

     var MM = (date.getMonth() < 10 ? '0' : '')
                         + (date.getMonth() );
     const lastdate=year+'-'+(MM)+'-'+lastDay
     var lastMM = (date.getMonth() < 10 ? '0' : '')
                         + (date.getMonth()-2);

     const firstdate=year+'-'+(lastMM)+'-'+firstDay
     console.log('https://develop.tryggkredit.net/data-provider/transaction/month?from='+firstdate+'&to='+lastdate+'&provider=tink')
      const config = {
        method: 'get',
        url:'https://develop.tryggkredit.net/data-provider/transaction/month?from='+firstdate+'&to='+lastdate+'&provider=tink',
        //url: 'https://develop-api.tryggkredit.net/data-provider/transaction/month?from=2022-02-01&to=2022-04-31&provider=tink',
        headers: {
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + localStorage.getItem("token")
        }
      };

      (axios(config)
        .then((response) => {

          localStorage.setItem('apiJason',JSON.stringify(response.data));
          this.showJasonResponse();

        })
        .catch(function (error) {
          console.log(error);
        })
      );

    },
    showJasonResponse() {

      const data = JSON.parse(localStorage.getItem("apiJason"));
      // const data = MockData;

      this.isAccountList = false;
      this.showAccountDetails = true;

      for (const category of this.expensesCategories) {

        const dataItems = data.categories.filter(it => category.tinkCategoryIds.includes(it.providerCategoryId));

        if (dataItems.length === 0) {

          category.spendTotal = 0;
          category.originalSpend = 0;
          category.incomeTotal = 0;
          category.lastSpend = 0;
          category.lastIncome = 0;

          for (const month of data.categories[0].transactions.map(it => it.month)) {
            category.spendPerMonth.push({ month, spend: 0 });
            category.incomePerMonth.push({ month, income: 0 });
          }

          continue;

        }

        for (const dataItem of dataItems) {
          for (const transaction of dataItem.transactions) {

            const spendItem = category.spendPerMonth.find(it => it.month === transaction.month);

            if (spendItem) {
              spendItem.spend += transaction.debtSum / 100;
            }
            else {
              category.spendPerMonth.push({
                month: transaction.month,
                spend: transaction.debtSum / 100
              });
            }


            const incomeItem = category.incomePerMonth.find(it => it.month === transaction.month);

            if (incomeItem) {
              incomeItem.income += transaction.creditSum / 100;
            }
            else {
              category.incomePerMonth.push({
                month: transaction.month,
                income: transaction.creditSum / 100
              });
            }


          }
        }

        category.spendTotal = sum( category.spendPerMonth.map(it => it.spend) );
        category.originalSpend = category.spendTotal;
        category.incomeTotal = sum( category.incomePerMonth.map(it => it.income) );

        category.lastSpend = category.spendPerMonth[category.spendPerMonth.length - 1].spend;
        category.lastIncome = category.incomePerMonth[category.incomePerMonth.length - 1].income;

        if (category.lastSpend > category.maxSpend / 2) {
          category.maxSpend = Math.ceil(category.lastSpend / 100) * 2 * 100;
        }

      }


      this.inkomstPerMonth = (data.categories.find(it => it.transactions.length > 0).transactions
        .map(it => it.month)
        .map(month => ({
          month,
          income: (data.account.incomes.find(it => it.month === month)?.value ?? 0) / 100
        }))
      );

      this.minRemainingPerMonth = (data.categories.find(it => it.transactions.length > 0).transactions
        .map(it => it.month)
        .map(month => ({
          month,
          remaining: (data.account.minBalances.find(it => it.month === month)?.value ?? 0) / 100
        }))
      );

      this.totalSpend = sum(this.expensesCategories.map(it => it.spendTotal));

      this.lastMonthIncomeSum = this.inkomstPerMonth[this.inkomstPerMonth.length - 1].income;
      this.lastMonthSpendSum  = sum( this.expensesCategories.map(it => it.lastSpend) );


      this.redigera.inkomst = this.inkomstPerMonth[this.inkomstPerMonth.length - 1].income;

      this.redigera.originalInkomst = this.redigera.inkomst;

      if (this.redigera.inkomst > this.redigera.maxInkomst / 2) {
        this.redigera.maxInkomst = Math.ceil(this.redigera.inkomst / 100) * 2 * 100;
      }

      this.redigera.categories = this.expensesCategories.map(it => ({
        ...it,
        lastSpend: it.lastSpend
      }));

      this.redigera.originalCategoriesSpendSum = sum(this.redigera.categories.map(it => it.lastSpend));

      this.redigera.kevarAtLeva = this.minRemainingPerMonth[this.minRemainingPerMonth.length - 1].remaining;
      this.redigera.originalKevarAtLeva = this.redigera.kevarAtLeva;

    },
    sum(...inp) {
      return sum(...inp);
    },
    showExpenseCalculator() {
      this.bankIdDialog = false;
      this.isExpenses = true;
      this.isBankList = false;
      this.isIncome = false;
    },
    showIncome() {
      this.isIncome = true;
      this.isBankList = false;
      this.isExpenses = false;
    },
    checkboxList(){
      for(let i = 0; i < this.selected.length; i++) {
        if (this.selected[i].checked == true) {
          this.isBankSelected = true;
        }
      }
    },
    fadeIn(el, time) {

      el.style.opacity = 0;
      el.style.display = "block";

      var last = +new Date();
      var tick = function() {
        el.style.opacity = +el.style.opacity + (new Date() - last) / time;
        last = +new Date();

        if (+el.style.opacity < 1) {
          (window.requestAnimationFrame && requestAnimationFrame(tick)) || setTimeout(tick, 16)
        }
      };

      tick();

    },
    getColourEnabled(enabledValue) {
      if (enabledValue == "") {
        return "disable-btn";
      }
      else {
        return "success-btn";
      }
    },
    async showBankAccount() {

      const config = {
        method: 'get',
        url: 'https://ttl-18h-ipd3bwtasq-ey.a.run.app/generalApi/V1/getAccount?ref='+this.bankId[0]+ '',
        headers: { }
      };

      (axios(config)
        .then((response) => {
          this.values = JSON.parse(JSON.stringify(response.data));
          this.setItems();
          this.paginationSize = Math.ceil(this.values.length / this.pageSize);
        })
        .catch((error) => {
          console.log(error);
        })
      );

    },
     async storeUser() {

      const makePersonNubmer = (length = 10) => {

          let chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';

          let str = '';
          for (let i = 0; i < length; i++) {
            str += chars.charAt(Math.floor(Math.random() * chars.length));
          }

          return str;

      };

      this.userId = makePersonNubmer(10);
      localStorage.setItem("userId", this.userId);

      const data = JSON.stringify({
        "userId": localStorage.getItem("userId")
      });

      const config = {
        method: 'post',
        url: 'https://develop.tryggkredit.net/data-provider/account/login',
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json'
        },
        data
      };


      let token;
      const wh = window.open();

      try {
        const response = await axios(config);
        token = response.data.token;
      }
      catch (error) {
        console.log(error);
        wh.close();
        return;
      }

      localStorage.setItem("token", token);


      const authenticationData = JSON.stringify({
        "redirect": location.origin + "/create",
        "test": false
      });

      const authenticationConfig = {
        method: 'post',
        url: 'https://develop.tryggkredit.net/data-provider/bank/tink/authenticate',
        headers: {
          'Content-Type': 'application/json',
          'Accept': 'application/json',
          'Authorization': 'Bearer ' + localStorage.getItem("token")
        },
        data: authenticationData
      };

      let redirectLink;

      try {
        const response = await axios(authenticationConfig);
        redirectLink = response.data.redirect;
      }
      catch (error) {
        console.log(error);
        wh.close();
        return;
      }

      wh.location.href = redirectLink;

    },
  }
};

</script>
