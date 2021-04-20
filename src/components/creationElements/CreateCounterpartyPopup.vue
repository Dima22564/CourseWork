<template>
  <div class="q-pa-lg" style="min-width: 500px">

    <q-form
      @submit="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
    >
      <q-input
        filled
        v-model="tin"
        label="ИНН"
        hint="ИНН"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="crtr"
        label="CRTR"
        hint="CRTR"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="workName"
        label="Сокращенное название"
        hint="Сокращенное название"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="fullName"
        label="Полное название"
        hint="Полное название"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

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
      workName: null,
      fullName: null,
      crtr: null,
      tin: null
    }
  },
  methods: {
    onSubmit () {
    },
    onReset () {
      this.workName = null
      this.fullName = null
      this.crtr = null
      this.tin = null
    }
  }
}
</script>
