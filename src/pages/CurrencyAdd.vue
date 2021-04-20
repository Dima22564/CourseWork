<template>
  <q-page padding>
    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
    >
      <q-input
        filled
        dense
        v-model="name"
        label="Название валюты"
        hint="Name and surname"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <q-input
        filled
        dense
        v-model="numericCode"
        label="Введите номер валюты"
        hint="Name and surname"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <q-input
        filled
        dense
        v-model="characterCode"
        label="Введите символьный код валюты"
        hint="Name and surname"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно к заполнению']"
      />

      <q-input
        filled
        dense
        v-model="exchangeRate"
        label="Введите обменный курс (к рублю)"
        hint="Name and surname"
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
      name: '',
      numericCode: '',
      characterCode: '',
      exchangeRate: '',
      loading: false
    }
  },
  methods: {
    onSubmit () {
      if (!this.loading) {
        this.$q.notify({
          color: 'green-4',
          textColor: 'white',
          icon: 'cloud_done',
          message: 'Submitted'
        })
      }
    },
    onReset () {
      this.name = ''
      this.numericCode = ''
      this.characterCode = ''
      this.exchangeRate = ''

      this.loading = true

      this.$q.notify({
        color: 'green-4',
        textColor: 'white',
        icon: 'cloud_done',
        message: 'Submitted'
      })
    }
  }
}
</script>
