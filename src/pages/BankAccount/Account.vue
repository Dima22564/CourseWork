<template>
  <q-page padding>
    <h5 class="q-ma-none q-mb-md">{{ name }}</h5>
    <q-card style="width: 600px" class="q-pa-md">
      <q-card-section class="row items-center justify-between q-pa-none no-wrap">
        <h6 class="text-primary text-weight-bold q-ma-none">Информация о счете.</h6>
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Название счета</span>
        <q-input :disable="loading" style="width: 300px" dense filled v-model="name" label="Название счета" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Компания</span>
        <q-select :disable="loading" options-selected-class="text-deep-orange" style="width: 300px" dense filled v-model="company" :options="companies" label="Компания" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Номер счета</span>
        <q-input :disable="loading" style="width: 300px" dense filled v-model="accountNumber" label="Номер счета" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-none no-wrap q-mt-md">
        <h6 class="text-primary text-weight-bold q-ma-none">Информация о банке, где открыт счет.</h6>
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">БИК банка</span>
        <q-select
          filled
          options-selected-class="text-deep-orange"
          style="width: 300px"
          v-model="bank"
          :options="banks"
          label="БИК банка"
          option-label="bic"
          :disable="loading"
        >
          <template v-slot:option="scope">
            <q-item
              v-bind="scope.itemProps"
              v-on="scope.itemEvents"
            >
              <q-item-section>
                <q-item-label>{{ scope.opt.name }}</q-item-label>
                <q-item-label caption>{{ scope.opt.bic }}</q-item-label>
              </q-item-section>
            </q-item>
          </template>
        </q-select>
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Корреспонденский счет банка</span>
        <q-input style="width: 300px" v-model="bank.corrAccount" dense filled readonly label="Корреспонденский счет" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Название банка</span>
        <q-input style="width: 300px" v-model="bank.name" dense filled readonly label="Название банка" />
      </q-card-section>

      <q-card-section class="row items-center justify-between q-pa-sm no-wrap">
        <span class="q-mr-lg" style="flex-shrink: 0">Город</span>
        <q-input style="width: 300px" v-model="bank.city" dense filled readonly label="Город"/>
      </q-card-section>

      <q-card-actions class="row items-center justify-between q-pa-sm no-wrap">
        <q-btn @click="save" color="primary" label="Сохранить" class="q-ml-auto" :loading="loading"/>
      </q-card-actions>
    </q-card>
  </q-page>
</template>

<script>
export default {
  name: 'AccountPage',
  data: () => {
    return {
      companies: ['Company'],
      banks: [{ name: 'Bank name', bic: 412841258412541, corrAccount: 525652525, city: 'Moscow' }],
      bank: {
        bic: null,
        name: null,
        corrAccount: null,
        city: null
      },
      company: 'ООО Ромашка',
      name: 'Расчетный счет ПАО Сбербанк',
      accountNumber: 185412841,
      loading: false
    }
  },
  methods: {
    save () {
      this.loading = true
    }
  }
}
</script>
