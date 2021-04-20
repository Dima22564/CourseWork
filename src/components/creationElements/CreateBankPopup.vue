<template>
  <div class="q-pa-lg" style="min-width: 500px">

    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
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

      <q-select dense filled v-model="country" hint="Страна" :options="countries" label="Страна" />

      <div class="flex justify-end">
        <q-btn label="Добавить" type="submit" color="primary"/>
        <q-btn label="Сбросить" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script>
export default {
  data: () => {
    return {
      name: '',
      tin: '',
      bic: '',
      address: '',
      country: '',
      corrAccount: '',
      city: '',
      countries: ['Россия']
    }
  },
  methods: {
    onSubmit () {
    },
    onReset () {
      this.name = ''
      this.tin = ''
      this.bic = ''
      this.address = ''
      this.country = ''
      this.city = ''
      this.corrAccount = ''
    }
  }
}
</script>
