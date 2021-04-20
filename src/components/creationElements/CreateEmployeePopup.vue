<template>
  <div class="q-pa-lg" style="min-width: 500px">

    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
    >
      <q-input
        filled
        v-model="fullName"
        label="Полное имя"
        hint="Полное имя"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="phone"
        label="Контактный телефон"
        hint="Контактный телефон"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <q-input
        filled
        v-model="email"
        label="Email"
        hint="Email"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <q-input
        filled
        v-model="tin"
        label="Инн"
        hint="Инн"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <q-input
        filled
        type="date"
        v-model="dateOfBirth"
        dense
        hint="Дата рождения"
        lazy-rules
        :rules="[
          val => val !== null && val !== '' || 'Поле обязательно для заполнени'
        ]"
      />

      <q-select dense filled v-model="gender" hint="Пол" :options="options" label="Пол" />
      <q-select dense filled v-model="position" hint="Должность" :options="positions" label="Должность" />

      <div>
        <q-btn label="Создать" type="submit" color="primary"/>
        <q-btn label="Сбросить" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script>
export default {
  data: () => {
    return {
      tin: '',
      gender: '',
      options: ['М', 'Ж'],
      fullName: '',
      email: '',
      phone: '',
      dateOfBirth: '',
      position: '',
      positions: ['dfd', 'dfd']
    }
  },
  methods: {
    onSubmit () {

    },
    onReset () {
      this.tin = ''
      this.gender = ''
      this.fullName = ''
      this.email = ''
      this.phone = ''
      this.dateOfBirth = ''
    }
  }
}
</script>
