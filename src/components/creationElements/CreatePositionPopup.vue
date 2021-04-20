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
        label="Название"
        hint="Название"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="desc"
        label="Описание"
        hint="Описание"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <q-input
        filled
        v-model="includeAt"
        hint="Действительна с даты"
        dense
        type="date"
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнени']"
      />

      <div>
        <q-btn label="Создать" type="submit" color="primary"/>
        <q-btn label="Сбросить" type="reset" color="primary" flat class="q-ml-sm" />
      </div>
    </q-form>

  </div>
</template>

<script>
import moment from 'moment'
export default {
  data: () => {
    return {
      name: '',
      desc: '',
      includeAt: moment().format('YYYY-MM-DD')
    }
  },
  methods: {
    onSubmit () {
    },
    onReset () {
      this.name = ''
      this.desc = ''
      this.includeAt = moment().format('YYYY-MM-DD')
    }
  }
}
</script>
