<template>
  <q-page padding>
    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
      ref="form"
    >
      <q-input
        filled
        dense
        v-model="name"
        label="Название валюты"
        hint="Название валюты"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <q-input
        filled
        dense
        v-model="numericCode"
        label="Введите номер валюты"
        hint="Введите номер валюты"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <q-input
        filled
        dense
        v-model="characterCode"
        label="Введите символьный код валюты"
        hint="Введите символьный код валюты"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <q-input
        filled
        dense
        v-model="exchangeRate"
        label="Введите обменный курс (к рублю)"
        hint="Введите обменный курс (к рублю)"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <div>
        <q-btn label="Добавить" size="md" type="submit" color="primary" :loading="loading"/>
        <q-btn label="Сбросить" size="md" type="reset" color="primary" flat class="q-ml-sm" :loading="loading" />
      </div>
    </q-form>

  </q-page>
</template>

<script>
export default {
  name: 'PageCurrencyAdd',
  data: () => {
    return {
      name: null,
      numericCode: null,
      characterCode: null,
      exchangeRate: null,
      loading: false
    }
  },
  methods: {
    async onSubmit () {
      const data = new FormData()
      data.append('Name', this.name)
      data.append('NumericCode', this.numericCode)
      data.append('CharacterCode', this.characterCode)
      data.append('ExchangeRate', this.exchangeRate)
      this.loading = true
      try {
        const result = await this.$store.dispatch('currency/create', data)
        if (result.status === 201) {
          this.$q.notify({
            type: 'positive',
            message: 'Валюта добавлена успешно'
          })
        }
        this.onReset()
      } catch (e) {
        this.$q.notify({
          type: 'negative',
          message: e.response.data
        })
      } finally {
        this.loading = false
      }
    },
    onReset () {
      this.name = null
      this.numericCode = null
      this.characterCode = null
      this.exchangeRate = null

      this.$refs.form.resetValidation()
    }
  }
}
</script>
