<template>
  <div class="q-pa-lg" style="min-width: 500px">

    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
      ref="form"
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

      <q-select
        :disable="loading"
        option-label="name"
        option-value="bic"
        dense
        filled
        v-model="form.bankBic"
        title="Банк, в котором открыт счет"
        hint="Банк"
        :options="banks"
        label="Банк"
      />

      <q-select
        :disable="loading"
        option-label="name"
        option-value="numericCode"
        dense
        filled
        v-model="form.currency"
        title="Валюта, в которой будет производиться расчет"
        hint="Валюта"
        :options="currencies"
        label="Валюта"
      />

      <q-select
        :disable="loading"
        :option-label="item => item.name.workName"
        option-value="tin"
        dense
        filled
        v-model="form.counterparty"
        title="Компания, за котрой закреплен данный счет"
        hint="Компания"
        :options="counterparties"
        label="Компания"
      />

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
      loading: false
    }
  },
  computed: {
    banks () {
      return this.$store.state.bank.banks
    },
    currencies () {
      return this.$store.state.currency.currencies
    },
    counterparties () {
      return this.$store.state.counterparty.counterparties
    }
  },
  async created () {
    if (this.currencies.length === 0) {
      await this.$store.dispatch('currency/fetchAll')
    }
    if (this.banks.length === 0) {
      await this.$store.dispatch('bank/fetchAll')
    }
    if (this.counterparties.length === 0) {
      await this.$store.dispatch('counterparty/fetchAll')
    }
    if (this.$route.params.tin) {
      this.form.counterparty = this.counterparties.find(x => x.tin === Number(this.$route.params.tin))
    }
  },
  methods: {
    async onSubmit () {
      const form = new FormData()
      form.append('AccountOpened', this.form.accountOpened)
      form.append('Name', this.form.name)
      form.append('AccountNumber', this.form.accountNumber)
      form.append('BankBic', this.form.bankBic.bic)
      form.append('CurrencyCode', this.form.currency.numericCode)
      form.append('CompanyId', this.form.counterparty.tin)
      try {
        const res = await this.$store.dispatch('bankAccount/create', form)
        if (res.status === 201) {
          this.$q.notify({
            type: 'positive',
            message: 'Банковский аккаунт успешно создан'
          })
        }
        console.log(res)
      } catch (e) {
        console.log(e.response)
        this.$q.notify({
          type: 'negative',
          message: e.response.data
        })
      }
    },
    onReset () {
      this.form.name = null
      this.form.accountOpened = null
      this.form.accountNumber = null
      this.form.bankBic = null
      this.form.currency = null
      this.form.counterparty = null

      this.$refs.form.resetValidation()
    }
  }
}
</script>
