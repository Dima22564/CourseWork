<template>
  <div class="q-pa-lg" style="min-width: 500px">

    <q-form
      @submit.prevent="onSubmit"
      @reset="onReset"
      class="q-gutter-md"
    >
      <q-input
        filled
        v-model="form.name"
        label="Название"
        hint="Название"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-input
        filled
        v-model="form.details"
        label="Примечания(описание)"
        hint="Примечания(описание)"
        dense
        lazy-rules
        :rules="[ val => val && val.length > 0 || 'Поле обязательно для заполнения']"
      />

      <q-select
        filled
        dense
        v-model="form.vat"
        :options="vatRates"
        label="Ставка НДС на данный тип продукта"
        hint="Ставка НДС на данный тип продукта"
      />

      <q-select
        filled
        dense
        v-model="form.type"
        :options="types"
        label="Тип продукта"
        hint="Тип продукта"
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
  name: 'CreateProductKindPopup',
  data: () => {
    return {
      form: {
        name: null,
        details: null,
        vat: null,
        type: null
      },
      vatRates: [0, 10, 18, 20],
      types: []
    }
  },
  methods: {
    onSubmit () {
    },
    onReset () {
      this.form.name = null
      this.form.details = null
      this.form.vat = null
      this.form.type = null
    }
  }
}
</script>
