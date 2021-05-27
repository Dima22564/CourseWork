<template>
  <q-page v-if="account !== null" padding>
    <h5 class="q-ma-none q-mb-md">{{ account.name }}</h5>
    <q-card style="width: 600px" class="q-pa-md" >
      <q-card-section class="row items-center justify-between q-pa-none no-wrap">
        <h6 class="text-primary text-weight-bold q-ma-none">Информация о счете.</h6>
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Название счета</span>
        <q-input readonly :disable="loading" style="width: 300px" dense filled v-model="account.name" label="Название счета" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Компания</span>
        <q-input readonly :disable="loading" style="width: 300px" dense filled v-model="account.company.name.workName" label="Компания" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Номер счета</span>
        <q-input readonly :disable="loading" style="width: 300px" dense filled v-model="account.accountNumber" label="Номер счета" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-none no-wrap q-mt-md">
        <h6 class="text-primary text-weight-bold q-ma-none">Информация о банке, где открыт счет.</h6>
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">БИК банка</span>
        <q-input readonly :disable="loading" style="width: 300px" dense filled v-model="account.bank.bic" label="БИК банка" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Корреспонденский счет банка</span>
        <q-input style="width: 300px" v-model="account.bank.corrAccount" dense filled readonly label="Корреспонденский счет" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Название банка</span>
        <q-input style="width: 300px" v-model="account.bank.name" dense filled readonly label="Название банка" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Город</span>
        <q-input style="width: 300px" v-model="account.bank.city" dense filled readonly label="Город"/>
      </q-card-section>

    </q-card>
  </q-page>
</template>

<script>
export default {
  name: 'AccountPage',
  data: () => {
    return {
      loading: false,
      account: null
    }
  },
  async created () {
    try {
      const res = await this.$store.dispatch('bankAccount/getById', this.$route.params.accountNumber)
      this.account = res.data
    } catch (e) {
      this.$q.notify({
        type: 'negative',
        message: e.response.data
      })
    }
  }
}
</script>
