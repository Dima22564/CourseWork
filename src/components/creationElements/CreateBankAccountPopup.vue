<template>
  <div class="q-pa-lg" style="min-width: 500px">

    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
    >
      <q-input
        filled
        v-model="form.accountNumber"
        label="Номер счета"
        hint="Номер счета"
        dense
        :disable="loading"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="form.name"
        label="Название счета"
        hint="Название счета"
        dense
        :disable="loading"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <q-input
        filled
        v-model="form.accountOpened"
        label="AccountOpened"
        hint="AccountOpened"
        dense
        :disable="loading"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <q-select :disable="loading" option-label="name" option-value="bic" dense filled v-model="form.bankBic" title="Банк, в котором открыт счет" hint="Банк" :options="banks" label="Банк" />

      <q-select :disable="loading" option-label="name" option-value="currencyId" dense filled v-model="form.currency" title="Валюта, в которой будет производиться расчет" hint="Валюта" :options="currencies" label="Валюта" />

      <q-select :disable="loading" option-label="name" option-value="counterpartyId" dense filled v-model="form.counterparty" title="Компания, за котрой закреплен данный счет" hint="Компания" :options="counterparties" label="Компания" />

      <div class="flex justify-end">
        <q-btn :loading="loading" :disable="loading" label="Добавить" type="submit" color="primary"/>
        <q-btn :loading="loading" :disable="loading" label="Сбросить" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script>
export default {
  name: 'CreateBankAccountPopup',
  data: () => {
    return {
      form: {
        accountOpened: null,
        name: null,
        accountNumber: null,
        bankBic: null,
        currency: null,
        counterparty: null
      },
      loading: false,
      currencies: [{ name: 'RUB', currencyId: 404 }],
      banks: [{ name: 'Bank', bic: '5125658256' }],
      counterparties: [{ name: 'Company', counterpartyId: 25 }]
    }
  },
  methods: {
    onSubmit () {
    },
    onReset () {
      this.form.name = null
      this.form.accountOpened = null
      this.form.accountNumber = null
    }
  }
}
</script>
