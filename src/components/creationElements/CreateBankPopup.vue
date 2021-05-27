<template>
  <div class="q-pa-lg" style="width: 500px">

    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
      ref="form"
    >
      <q-input
        filled
        v-model="name"
        label="Название банка"
        hint="Название банка"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="bic"
        label="БИК банка"
        hint="БИК банка"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <q-input
        filled
        v-model="tin"
        label="ИНН банка"
        hint="ИНН банка"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <q-input
        filled
        v-model="city"
        label="Город"
        hint="Город"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <q-input
        filled
        v-model="corrAccount"
        dense
        label="Корреспонденский счет"
        hint="Корреспонденский счет"
        lazy-rules
        :rules="[
          val => val !== null && val !== '' || 'Поле обязательно для заполнени'
        ]"
      />

      <q-input
        filled
        v-model="address"
        dense
        label="Адрес"
        hint="Адрес"
        lazy-rules
        :rules="[
          val => val !== null && val !== '' || 'Поле обязательно для заполнени'
        ]"
      />

      <q-select
        options-selected-class="text-deep-orange"
        option-value="code"
        option-label="name"
        dense
        filled
        v-model="country"
        hint="Страна"
        :options="countries"
        label="Страна"
      />

      <div class="flex justify-end">
        <q-btn :loading="loading" label="Добавить" type="submit" color="primary"/>
        <q-btn :loading="loading" label="Сбросить" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script>
export default {
  data: () => {
    return {
      name: null,
      tin: null,
      bic: null,
      address: null,
      country: null,
      corrAccount: null,
      city: null,
      loading: false
    }
  },
  created () {
    if (this.$store.state.country.countries.length === 0) {
      this.$store.dispatch('country/fetchAll')
    }
  },
  computed: {
    countries () {
      return this.$store.state.country.countries
    }
  },
  methods: {
    async onSubmit () {
      const form = new FormData()
      form.append('Name', this.name)
      form.append('Bic', this.bic)
      form.append('Tin', this.tin)
      form.append('City', this.city)
      form.append('CorrAccount', this.corrAccount)
      form.append('Address', this.address)
      form.append('CountryCode', this.country.code)

      this.loading = true
      try {
        const result = await this.$store.dispatch('bank/create', form)
        if (result.status === 201) {
          this.$q.notify({
            type: 'positive',
            message: 'Банк добавлен успешно'
          })
        }
        this.onReset()
      } catch (e) {
        console.log(e.response)
        this.$q.notify({
          type: 'negative',
          message: e.response.data.message
        })
      } finally {
        this.loading = false
      }
    },
    onReset () {
      this.name = null
      this.tin = null
      this.bic = null
      this.address = null
      this.country = null
      this.city = null
      this.corrAccount = null

      this.$refs.form.resetValidation()
    }
  }
}
</script>
